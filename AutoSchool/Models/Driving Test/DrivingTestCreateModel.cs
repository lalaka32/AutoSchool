using System.Collections.Generic;

namespace AutoSchool.Models
{
    public class DrivingTestCreateModel
    {
        public bool? Success { get; set; }
        
        public IEnumerable<RoadSituationCreateModel> RoadSituations { get; set; }
    }
}