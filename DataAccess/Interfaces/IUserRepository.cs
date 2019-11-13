using Common.DataContracts.User;
using System.Collections.Generic;
using Common.BusinessObjects;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        int Create(UserCreateDto dto);

        IReadOnlyCollection<User> Search(UserCollectionFilterDto filter);

        User Get(int id);
    }
}
