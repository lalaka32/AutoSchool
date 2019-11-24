using Common.DataContracts.Abstact;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts.User
{
    public class UserCollectionFilterDto : CollectionFilterDto
    {
        public string Login { get; set; }

        public IEnumerable<int> ExcludeRoles { get; set; }
    }
}
