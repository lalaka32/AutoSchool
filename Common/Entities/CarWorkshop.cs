using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class CarWorkshop
    {

        public int Id { get; set; }
        public ICollection<Car> Cars { get; set; }

        public CarWorkshop()
        {
            Cars = new List<Car>();
        }
    }
}
