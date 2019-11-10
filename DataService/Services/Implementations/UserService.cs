using System.Collections.Generic;
using AutoMapper;
using Common.DataContracts.User;
using Common.Ecxeptions;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;

namespace DataService.Services.Implementations
{
    public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
		{
            _userRepository = userRepository;
            _mapper = mapper;
		}

        public int CreateAdmin(UserCreateDto dto)
        {
            var userWithSameLogin = _userRepository.Search(new UserCollectionFilterDto
            {
                Login = dto.Login
            });
            if (userWithSameLogin.Count > 0)
            {
                throw new BadOperationException(ErrorCode.LoginOccupied);
            }
            dto.RoleId = 1;
            return _userRepository.Create(dto);
        }

        public IReadOnlyCollection<UserCollectionItemDto> Search(UserCollectionFilterDto filter)
        {
            var result = _userRepository.Search(filter);
            return _mapper.Map<IReadOnlyCollection<UserCollectionItemDto>>(result);
        }
    }
}
