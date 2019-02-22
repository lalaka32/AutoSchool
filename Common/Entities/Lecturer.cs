using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	class Lecturer
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }
	}
}
