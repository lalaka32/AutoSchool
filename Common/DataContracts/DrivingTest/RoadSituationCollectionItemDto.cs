namespace Common.DataContracts.DrivingTest
{
    public class RoadSituationCollectionItemDto
    {
        public int Id { get; set; }

        public int DrivingTestId { get; set; }

        public DrivingTestDto DrivingTest { get; set; }

        public bool HasSigns { get; set; }

        public bool HasTrafficLight { get; set; }

        public bool HasVip { get; set; }
        
        public bool Success { get; set; }
    }
}