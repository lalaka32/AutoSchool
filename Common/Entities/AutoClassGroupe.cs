using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	public class AutoClassGroupe
	{
		public int Id { get; set; }

		public int LecturerId { get; set; }

		public User Lecturer { get; set; }

		public int StudentId { get; set; }

		public User Student { get; set; }

		public int CategoryOfDriverLicenceId { get; set; }

		public CategoryOfDriverLicence CategoryOfDriverLicence { get; set; }
	}
}
