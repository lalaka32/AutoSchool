using Common.BisnessObjects;
using Common.DataContracts.User;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        int Create(UserCreateDto dto);

        IReadOnlyCollection<User> Search(UserCollectionFilterDto filter);
    }
}
