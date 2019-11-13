using System;
using System.Collections.Generic;
using System.Text;
using Common.BusinessObjects;

namespace Common.Entities
{
    public class Progress
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public User User { get; set; }

        public int CreatorId { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
