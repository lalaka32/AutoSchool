using System;

namespace Common.DataContracts.AutoSchoolGroup
{
    public class AutoSchoolGroupCollectionItemDto
    {
        public int Id { get; set; }

        public int AutoSchoolId { get; set; }

        public string Name { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}