using Common.DataContracts.User;
using System.Collections.Generic;
using Common.BusinessObjects;
using Common.Entities;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        int Create(UserCreateDto dto);

        IReadOnlyCollection<User> Search(UserCollectionFilterDto filter);

        User Get(int id);
        
        IReadOnlyCollection<Role> GetRoles();
        bool Update(UserUpdateDto userDto);
    }
}
