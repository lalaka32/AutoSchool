using Common.BisnessObjects;
using System;

namespace Common.Entities
{
    class UserDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public User User { get; set; }

        public int CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
