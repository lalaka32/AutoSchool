using Common.DataContracts.User;
using Common.Ecxeptions;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IAuthenticationService = DataService.Services.Interfaces.IAuthenticationService;

namespace DataService.Services.Implementations
{
    public class CookieAuthenticationService : IAuthenticationService
    {
        private readonly IHttpContextAccessor _context;
        private readonly IUserService _userService;

        public CookieAuthenticationService(IHttpContextAccessor context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task Login(UserLoginDto dto)
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
            await SignIn(user.Id, dto.Login);
        }

        public async Task Logout()
        {
            await _context.HttpContext.SignOutAsync(
             CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task SignUp(UserCreateDto dto)
        {
            var id = _userService.CreateAdmin(dto);
            await SignIn(id, dto.Login);
        }

        private async Task SignIn(int id, string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim(ClaimTypes.PrimarySid, id.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24),

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                RedirectUri = "Login"
            };

            await _context.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}
