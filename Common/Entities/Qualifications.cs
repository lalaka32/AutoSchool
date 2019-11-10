using Common.BisnessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	public class Qualifications
	{
		public int Id { get; set; }

		public int CategoryOfDriverLicenceId { get; set; }

		public CategoryOfDriverLicence CategoryOfDriverLicence { get; set; }

		public int LecturerId { get; set; }

		public User Lecturer { get; set; }
	}
}
