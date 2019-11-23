using Common.BusinessObjects;

namespace Common.Entities
{
    public class RoadSituation
    {
        public int Id { get; set; }

        public int DrivingTestId { get; set; }

        public DrivingTest DrivingTest { get; set; }

        public bool Success { get; set; }

        public bool HasSigns { get; set; }

        public bool HasTrafficLight { get; set; }

        public bool HasVip { get; set; }
    }
}