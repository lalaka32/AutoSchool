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

		public int RulesSectionId { get; set; }

		public RulesSection RulesSection { get; set; }

		public bool Success { get; set; }
	}
}
