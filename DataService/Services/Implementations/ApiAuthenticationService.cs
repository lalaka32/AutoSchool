using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
using Common.Authorization;
using Common.DataContracts.User;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DataService.Services.Implementations
{
    public class ApiAuthenticationService : IAuthenticationService
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IHttpContextAccessor _contextAccessor;

        public ApiAuthenticationService(IJwtAuthenticationService jwtAuthenticationService,
            IHttpContextAccessor contextAccessor)
        {
            _jwtAuthenticationService = jwtAuthenticationService;
            _contextAccessor = contextAccessor;
        }

        public async Task<int> Login(UserLoginDto dto)
        {
            return await Task.FromResult(_jwtAuthenticationService.Login(dto));
        }

        public async Task Logout()
        {
            await _jwtAuthenticationService.Logout();
        }

        public int GetCurrentUserId()
        {
            var userIdString = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x =>
                x.Type.Equals(JwtRegisteredClaimNames.Jti, StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (userIdString == null)
            {
                throw new MissingFieldException("Id is null");
            }

            return int.Parse(userIdString);
        }
    }
}