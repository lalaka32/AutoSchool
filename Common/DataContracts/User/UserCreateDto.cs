using System;
using System.Collections.Generic;
using System.Text;
using Common.Enums.User;

namespace Common.DataContracts.User
{
    public class UserCreateDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public Role RoleId { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
