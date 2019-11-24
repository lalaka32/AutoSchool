using System.Threading.Tasks;
using Common.DataContracts.User;

namespace DataService.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<int> Login(UserLoginDto dto);

        Task Logout();
        
        int GetCurrentUserId();
    }
}