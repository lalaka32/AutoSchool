using System;
using System.Collections.Generic;
using System.Text;
using Common.BusinessObjects;

namespace Common.Entities
{
	public class DrivingMaster
	{
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public CategoryOfDriverLicence Category { get; set; }
    }
}
