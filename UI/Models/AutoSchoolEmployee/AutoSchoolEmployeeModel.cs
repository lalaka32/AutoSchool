using UI.Models.AutoSchool;
using UI.Models.User;

namespace UI.Models.AutoSchoolEmployee
{
    public class AutoSchoolEmployeeModel
    {
        public int Id { get; set; }

        public int LecturerId { get; set; }

        public UserModel Lecturer { get; set; }

        public int AutoSchoolId { get; set; }

        public AutoSchoolModel AutoSchool { get; set; }
    }
}