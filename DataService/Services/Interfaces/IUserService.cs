using Common.DataContracts.User;
using System.Collections.Generic;

namespace DataService.Services.Interfaces
{
    public interface IUserService
	{
        int Create(UserCreateDto dto);
        
        UserDto Get(int id);
        
        //int CreateAdmin(UserCreateDto dto);
        
        IReadOnlyCollection<UserCollectionItemDto> Search(UserCollectionFilterDto filter);
    }
}
