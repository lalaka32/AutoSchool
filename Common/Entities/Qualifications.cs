﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	class Qualifications
	{
		public int Id { get; set; }

		public int CategoryOfDriverLicenceId { get; set; }

		public CategoryOfDriverLicence CategoryOfDriverLicence { get; set; }

		public int LecturerId { get; set; }

		public Lecturer Lecturer { get; set; }
	}
}
