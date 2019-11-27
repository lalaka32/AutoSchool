using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts.User
{
    public class UserCollectionItemDto
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public int RoleId { get; set; }
        
        public string RoleName { get; set; }
    }
}
