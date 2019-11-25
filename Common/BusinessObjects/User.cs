using Common.Entities;

namespace Common.BusinessObjects
{
	public class User
	{
		public int Id { get; set; }

		public int RoleId { get; set; }

		public Role Role { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public int? AutoClassGroupId { get; set; }

		public AutoClassGroup AutoClassGroup { get; set; }

       // public int ProgressId { get; set; }
       
       // public Progress Progress { get; set; }
    }
}
