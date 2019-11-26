using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts.DrivingTest
{
    public class DrivingTestDto
    {
        public int Id { get; set; }

        public string RuleSectionName { get; set; }

        public IEnumerable<RoadSituationCollectionItemDto> RoadSituations { get; set; }

        public bool? Success { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
