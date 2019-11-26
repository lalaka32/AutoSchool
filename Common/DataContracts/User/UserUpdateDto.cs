namespace Common.DataContracts.User
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public int RoleId { get; set; }

        public int? AutoSchoolId { get; set; }

        public int? GroupId { get; set; }
    }
}