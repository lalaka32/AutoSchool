using System.ComponentModel.DataAnnotations;

namespace UI.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Login { get; set; }
        
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}