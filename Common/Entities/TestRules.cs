using Common.BisnessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
	public class TestRules
	{
		public int Id { get; set; }

		public int RulesSectionId { get; set; }

		public RulesSection RulesSections { get; set; }

		public int DrivingTestId { get; set; }

		public DrivingTest DrivingTest { get; set; }
	}
}
