using System.Collections.Generic;

namespace Common.DataContracts.DrivingTest
{
    public class DrivingTestCreateDto
    {
        public bool? Success { get; set; }
        
        public IEnumerable<RoadSituationCreateDto> RoadSituation { get; set; }
    }
}