using System.Collections.Generic;
using AutoMapper;
using Common.BusinessObjects;
using Common.DataContracts.User;
using Common.Ecxeptions;
using Common.Enums.User;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;

namespace DataService.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEncryptionService _encryptionService;

        private readonly Dictionary<Role, IEnumerable<int>> _roleExcludeRoles = new Dictionary<Role, IEnumerable<int>>()
        {
            {Role.Administrator, new List<int>()},
            {
                Role.AutoSchoolAdministrator,
                new List<int> {(int) Role.Administrator, (int) Role.AutoSchoolAdministrator}
            },
            {
                Role.AutoSchoolEmployee,
                new List<int>
                    {(int) Role.Administrator, (int) Role.AutoSchoolAdministrator, (int) Role.AutoSchoolEmployee}
            },
        };

        public UserService(IUserRepository userRepository, IMapper mapper, IAuthenticationService authenticationService,
            IEncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationService = authenticationService;
            _encryptionService = encryptionService;
        }

        public int Create(UserCreateDto dto)
        {
            var userWithSameLogin = _userRepository.Search(
                new UserCollectionFilterDto
                {
                    Login = dto.Login
                });
            if (userWithSameLogin.Count > 0)
            {
                throw new BadOperationException(ErrorCode.LoginOccupied);
            }

            var entity = _mapper.Map<User>(dto);
            var data = _encryptionService.GenerateKey();
            entity.Key = data.Key;
            entity.IV = data.IV;
            entity.Name = dto.Name == null ? null : _encryptionService.Encrypt(dto.Name, entity.Key, entity.IV);
            entity.Address = dto.Address == null ? null : _encryptionService.Encrypt(dto.Address, entity.Key, entity.IV);
            entity.Email = dto.Email == null ? null : _encryptionService.Encrypt(dto.Email, entity.Key, entity.IV);
            entity.PhoneNumber = dto.PhoneNumber == null ? null : _encryptionService.Encrypt(dto.PhoneNumber, entity.Key, entity.IV);
            entity.Password = dto.Password == null ? null : _encryptionService.Encrypt(dto.Password, entity.Key, entity.IV);
            return _userRepository.Create(entity);
        }

        public UserDto Get(int id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<UserDto>(user);
        }

        public UserDto GetCurrentUser()
        {
            var user = _userRepository.Get(_authenticationService.GetCurrentUserId());
            return _mapper.Map<UserDto>(user);
        }

        public IReadOnlyCollection<UserCollectionItemDto> Search(UserCollectionFilterDto filter)
        {
            if (filter.Login == null)
            {
                var currentUser = _userRepository.Get(_authenticationService.GetCurrentUserId());

                filter.ExcludeRoles = _roleExcludeRoles[(Role) currentUser.RoleId];
            }

            var result = _userRepository.Search(filter);
            return _mapper.Map<IReadOnlyCollection<UserCollectionItemDto>>(result);
        }

        public IReadOnlyCollection<RoleDto> GetAllRoles()
        {
            var dtos = _userRepository.GetRoles();
            return _mapper.Map<IReadOnlyCollection<RoleDto>>(dtos);
        }

        public int Update(UserUpdateDto userDto)
        {
            _userRepository.Update(userDto);
            return userDto.Id;
        }
    }
}