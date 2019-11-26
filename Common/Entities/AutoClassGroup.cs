using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	public class AutoClassGroup
	{
		public int Id { get; set; }

		public int LecturerId { get; set; }

		public AutoSchoolEmployee Lecturer { get; set; }

		public string Name { get; set; }

		public int CategoryOfDriverLicenceId { get; set; }

	    public CategoryOfDriverLicence CategoryOfDriverLicence { get; set; }
	    
	    public DateTime CreatedAt { get; set; }
		
	    public DateTime UpdatedAt { get; set; }
	}
}
