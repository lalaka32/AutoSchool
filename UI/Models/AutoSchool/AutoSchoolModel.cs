using System.ComponentModel.DataAnnotations;

namespace UI.Models.AutoSchool
{
    public class AutoSchoolModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}