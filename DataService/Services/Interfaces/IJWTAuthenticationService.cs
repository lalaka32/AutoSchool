using Common.DataContracts.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services.Interfaces
{
    public interface IJWTAuthenticationService
    {
        Task<int> Login(UserLoginDto dto);

        Task Logout();

        Task<string> GenerateJSONWebToken(int userId);
    }
}
