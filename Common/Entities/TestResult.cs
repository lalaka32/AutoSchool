using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	public class TestResult
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public ICollection<TestRules> RulesSections { get; set; }

		public bool Success { get; set; }

		public TestResult()
		{
			RulesSections = new List<TestRules>();
		}
	}
}
