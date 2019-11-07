using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	public class User
	{
		public int Id { get; set; }

		public int RoleId { get; set; }

		public Role Role { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }
	}
}
