using Common.DataContracts.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task SignUp(UserCreateDto dto);

        Task Login(UserLoginDto dto);

        Task Logout();
    }
}
