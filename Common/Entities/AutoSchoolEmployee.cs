using System;
using System.Collections.Generic;
using System.Text;
using Common.BusinessObjects;

namespace Common.Entities
{
	public class AutoSchoolEmployee
	{
		public int Id { get; set; }

		public int AutoSchoolId { get; set; }

		public AutoSchool AutoSchool { get; set; }

		public int LecturerId { get; set; }

		public User Lecturer { get; set; }
	}
}
