using UI.Models.AutoSchool;

namespace UI.Models.User
{
    public class AutoSchoolAdminModel
    {
        public int Id { get; set; }

        public int AdminId { get; set; }

        public UserModel Admin { get; set; }

        public int AutoSchoolId { get; set; }

        public AutoSchoolModel AutoSchool { get; set; }
    }
}