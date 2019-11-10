using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts.User
{
    public class UserCreateDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}
