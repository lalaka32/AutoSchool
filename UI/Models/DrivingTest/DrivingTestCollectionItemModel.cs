using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models.DrivingTest
{
    public class DrivingTestCollectionItemModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public bool? Success { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
