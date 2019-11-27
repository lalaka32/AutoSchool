using Common.DataContracts.User;
using System.Collections.Generic;

namespace DataService.Services.Interfaces
{
    public interface IUserService
	{
        int Create(UserCreateDto dto);
        
        UserDto Get(int id);

        UserDto GetCurrentUser();
        
        IReadOnlyCollection<UserCollectionItemDto> Search(UserCollectionFilterDto filter);

        IReadOnlyCollection<RoleDto> GetAllRoles();
        
        int Update(UserUpdateDto userDto);
    }
}
