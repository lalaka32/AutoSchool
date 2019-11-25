using System;
using System.ComponentModel.DataAnnotations;

namespace UI.Models.AutoSchoolGroup
{
    public class AutoSchoolGroupModel
    {
        public int Id { get; set; }

        public int AutoSchoolId { get; set; }

        public int LecturerId { get; set; }

        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}