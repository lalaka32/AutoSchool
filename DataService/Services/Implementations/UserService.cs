using System.Collections.Generic;
using AutoMapper;
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

        public UserService(IUserRepository userRepository, IMapper mapper, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationService = authenticationService;
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

            return _userRepository.Create(dto);
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
    }
}