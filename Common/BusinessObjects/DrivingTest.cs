using System;
using System.Collections.Generic;
using Common.Entities;

namespace Common.BusinessObjects
{
    public class DrivingTest
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int RulesSectionId { get; set; }
        
        public RulesSection RulesSection { get; set; }

        public ICollection<RoadSituation> RoadSituation { get; set; }

        public DateTime AddedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool? Success { get; set; }

        public DrivingTest()
        {
            RoadSituation = new List<RoadSituation>();
        }
    }
}