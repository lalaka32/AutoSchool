using Common.DataContracts.User;
using DataService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services.Implementations
{
    class JWTAuthenticationService : IJWTAuthenticationService
    {
        public Task<string> GenerateJSONWebToken(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Login(UserLoginDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task SignUp(UserCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
