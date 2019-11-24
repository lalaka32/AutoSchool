using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
using Common.Authorization;
using Common.BusinessObjects;
using Common.DataContracts.User;
using Common.Ecxeptions;
using Common.Enums.User;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DataService.Services.Implementations
{
    public class AdminAuthenticationService : IAuthenticationService
    {
        private readonly ICookieAuthenticationService _cookieAuthenticationService;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly IEnumerable<Role> _rolesHasAccessToAdminSite = new[]
            {Role.Administrator, Role.AutoSchoolAdministrator, Role.AutoSchoolEmployee};

        public AdminAuthenticationService(ICookieAuthenticationService cookieAuthenticationService,
            IUserRepository userRepository, IHttpContextAccessor contextAccessor)
        {
            _cookieAuthenticationService = cookieAuthenticationService;
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<int> Login(UserLoginDto dto)
        {
            User user = null;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                user = _userRepository.Search(new UserCollectionFilterDto()
                {
                    Login = dto.Login
                }).FirstOrDefault();

                if (user != null)
                {
                    if (!_rolesHasAccessToAdminSite.Contains((Role) user.RoleId))
                    {
                        throw new ForbiddenException();
                    }
                }

                await _cookieAuthenticationService.Login(dto);

                scope.Complete();
            }

            return await Task.FromResult(user.Id);
        }

        public async Task Logout()
        {
            await _cookieAuthenticationService.Logout();
        }

        public int GetCurrentUserId()
        {
            var stringId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c =>
                c.Type.Equals(ClaimTypes.PrimarySid, StringComparison.InvariantCultureIgnoreCase))?.Value;
            if (stringId == null)
            {
                throw new MissingFieldException("Id is null");
            }

            return int.Parse(stringId);
        }
    }
}