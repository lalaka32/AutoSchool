using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoSchool.Authorization;
using Common.Entities;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AutoSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IRegistrationService _registrationService;

        public AuthController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Register([FromBody]User userToRegistry)
        {
            var withLoginExist = _registrationService.UserWithLoginExist(userToRegistry.Login);

            if (withLoginExist)
            {
                const string LoginTakenErrorMessage = "Login is already taken";
                return BadRequest(new { error = LoginTakenErrorMessage });
            }
            _registrationService.AddUser(userToRegistry);

            var tokenString = GenerateJSONWebToken(userToRegistry);

            return Ok(new { token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody]User loginUser)
        {
            var user = _registrationService.GetUserByLogin(loginUser.Login);
            if (user == null)
            {
                const string LoginNotCorrectErrorMessage = "No users with this login";
                return Unauthorized(new { error = LoginNotCorrectErrorMessage });
            }
            if (user.Password != loginUser.Password)
            {
                const string PasswordErrorMessgae = "Wrong password";
                return Unauthorized(new { error = PasswordErrorMessgae });
            }

            var tokenString = GenerateJSONWebToken(user);

            return Ok(new { token = tokenString });
        }

        public string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = AuthOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, userInfo.Login),
                        new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())};

            var token = new JwtSecurityToken(AuthOptions.ISSUER,
            AuthOptions.AUDIENCE,
            claims,
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}