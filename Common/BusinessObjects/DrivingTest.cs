﻿using System;
using System.Collections.Generic;
using Common.Entities;

namespace Common.BusinessObjects
{
    public class DrivingTest
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int RuleSectionId { get; set; }
        
        public RuleSection RuleSection { get; set; }

        public ICollection<RoadSituation> RoadSituations { get; set; }

        public DateTime AddedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool? Success { get; set; }

        public DrivingTest()
        {
            RoadSituations = new List<RoadSituation>();
        }
    }
}