using System.ComponentModel.DataAnnotations;

namespace AutoSchool.Models.User
{
    public class UserLoginModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}