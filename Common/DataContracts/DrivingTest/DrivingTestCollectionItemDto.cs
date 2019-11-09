using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts.DrivingTest
{
    public class DrivingTestCollectionItemDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public bool? Success { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
