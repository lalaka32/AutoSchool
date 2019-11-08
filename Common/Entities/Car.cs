using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public CategoryOfDriverLicence Category { get; set; }
        public string Status { get; set; }
        public ICollection<CarWorkshop> CarWorkshops { get; set; }

        public Car()
        {
            CarWorkshops = new List<CarWorkshop>();
        }
    }
}
