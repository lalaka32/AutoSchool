using System.ComponentModel.DataAnnotations;

namespace AutoSchool.Models.User
{
    public class UserRegistryModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
