using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.BisnessObjects
{
	public class DrivingTest
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public ICollection<TestRules> RulesSections { get; set; }

        public DateTime AddedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool? Success { get; set; }

		public DrivingTest()
		{
			RulesSections = new List<TestRules>();
		}
	}
}
