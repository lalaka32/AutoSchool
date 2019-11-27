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
using DataAccess.Interfaces;
using ICookieAuthenticationService = DataService.Services.Interfaces.ICookieAuthenticationService;

namespace DataService.Services.Implementations
{
    public class CookieAuthenticationService : ICookieAuthenticationService
    {
        private readonly IHttpContextAccessor _context;
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;

        public CookieAuthenticationService(IHttpContextAccessor context, IUserRepository userRepository, IEncryptionService encryptionService)
        {
            _context = context;
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }

        public async Task Login(UserLoginDto dto)
        {
            var user = _userRepository.Search(new UserCollectionFilterDto
            {
                Login = dto.Login
            }).FirstOrDefault();
            if (user == null)
            {
                throw new BadOperationException(ErrorCode.WrongLogin);
            }

            if (_encryptionService.Decrypt(user.Password, user.Key, user.IV) != dto.Password)
            {
                throw new BadOperationException(ErrorCode.WrongPassword);
            }

            await SetCookie(user.Id, dto.Login);
        }

        public async Task Logout()
        {
            await _context.HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private async Task SetCookie(int id, string login)
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