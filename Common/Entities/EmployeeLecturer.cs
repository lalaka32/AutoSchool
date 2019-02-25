using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	public class EmployeeLecturer
	{
		public int Id { get; set; }

		public int AutoSchoolId { get; set; }

		public AutoSchool AutoSchool { get; set; }

		public int LecturerId { get; set; }

		public Lecturer Lecturer { get; set; }
	}
}
