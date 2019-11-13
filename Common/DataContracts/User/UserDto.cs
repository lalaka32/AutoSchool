using Common.Enums.User;

namespace Common.DataContracts.User
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Login { get; set; }
        
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}