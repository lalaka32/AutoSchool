using System.ComponentModel.DataAnnotations;

namespace AutoSchool.Models.User
{
    public class UserRegistryModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
