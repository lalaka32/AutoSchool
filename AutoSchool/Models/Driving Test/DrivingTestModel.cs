using Common.DataContracts.DrivingTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSchool.Models.Driving_Test
{
    public class DrivingTestModel
    {
        public int Id { get; set; }

        public string RuleSectionName { get; set; }

        public IEnumerable<RoadSituationCollectionItemModel> RoadSituations { get; set; }

        public bool? Success { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
