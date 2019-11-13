using Common.DataContracts.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services.Interfaces
{
    public interface IJwtAuthenticationService
    {
        int Login(UserLoginDto dto);

        Task Logout();

        string GenerateJsonWebToken(int userId);
    }
}
