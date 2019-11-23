namespace AutoSchool.Models
{
    public class RoadSituationCreateModel
    {
        public bool HasSigns { get; set; }

        public bool HasTrafficLight { get; set; }

        public bool HasVip { get; set; }
        
        public bool Success { get; set; }
    }
}