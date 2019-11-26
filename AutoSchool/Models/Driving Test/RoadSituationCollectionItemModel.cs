using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSchool.Models.Driving_Test
{
    public class RoadSituationCollectionItemModel
    {
        public int Id { get; set; }

        public int DrivingTestId { get; set; }

        public DrivingTestModel DrivingTest { get; set; }

        public bool HasSigns { get; set; }

        public bool HasTrafficLight { get; set; }

        public bool HasVip { get; set; }

        public bool Success { get; set; }
    }
}
