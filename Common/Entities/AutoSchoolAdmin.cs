using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	public class AutoSchoolAdmin
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public int AutoSchoolId { get; set; }

		public AutoSchool AutoSchool { get; set; }
	}
}
