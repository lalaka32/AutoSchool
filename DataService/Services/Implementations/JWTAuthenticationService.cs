﻿using Common.DataContracts.User;
using DataService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.Authorization;
using Common.Ecxeptions;
using Microsoft.IdentityModel.Tokens;

namespace DataService.Services.Implementations
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly IUserService _userService;

        public JwtAuthenticationService(IUserService userService)
        {
            _userService = userService;
        }
        public string GenerateJsonWebToken(int userId)
        {
            var user = _userService.Get(userId);
            
            var securityKey = AuthOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Login),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())};

            var token = new JwtSecurityToken(AuthOptions.ISSUER,
                AuthOptions.AUDIENCE,
                claims,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public int Login(UserLoginDto dto)
        {
            var user = _userService.Search(new UserCollectionFilterDto
            {
                Login = dto.Login
            }).FirstOrDefault();
            if (user == null)
            {
                throw new BadOperationException(ErrorCode.WrongLogin);
            }
            if (user.Password != dto.Password)
            {
                throw new BadOperationException(ErrorCode.WrongPassword);
            }

            return user.Id;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}