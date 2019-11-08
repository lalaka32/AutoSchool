using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Entities
{
    public class Progress
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public int Points { get; set; }
        public User User { get; set; }

        public int CreatorId { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
