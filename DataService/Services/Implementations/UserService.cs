using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using AutoMapper;
using Common.DataContracts.User;
using Common.Ecxeptions;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DataService.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
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
            var userIdString = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x =>
                x.Type.Equals(JwtRegisteredClaimNames.Jti, StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (userIdString == null)
            {
                throw new MissingFieldException("Id is null");
            }

            var user = _userRepository.Get(int.Parse(userIdString));
            return _mapper.Map<UserDto>(user);
        }

        public IReadOnlyCollection<UserCollectionItemDto> Search(UserCollectionFilterDto filter)
        {
            var result = _userRepository.Search(filter);
            return _mapper.Map<IReadOnlyCollection<UserCollectionItemDto>>(result);
        }
    }
}