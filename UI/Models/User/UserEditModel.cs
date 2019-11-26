using System.ComponentModel.DataAnnotations;

namespace UI.Models.User
{
    public class UserEditModel
    {
        public int Id { get; set; }

        public string Login { get; set; }
        
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        public int? AutoSchoolId { get; set; }

        public int? GroupId { get; set; }
    }
}