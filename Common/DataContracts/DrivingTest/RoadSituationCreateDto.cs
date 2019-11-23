namespace Common.DataContracts.DrivingTest
{
    public class RoadSituationCreateDto
    {
        public bool HasSigns { get; set; }

        public bool HasTrafficLight { get; set; }

        public bool HasVip { get; set; }
        
        public bool Success { get; set; }
    }
}