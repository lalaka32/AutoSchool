using Common.Entities;

namespace Common.BusinessObjects
{
	public class User
	{
		public int Id { get; set; }

		public int RoleId { get; set; }

		public Role Role { get; set; }

		public string Login { get; set; }

		public byte[] Password { get; set; }

		public int? AutoClassGroupId { get; set; }

		public AutoClassGroup AutoClassGroup { get; set; }

		public byte[] Name { get; set; }

		public byte[] Address { get; set; }

		public byte[] Email { get; set; }

		public byte[] PhoneNumber { get; set; }

		public byte[] Key { get; set; }

		public byte[] IV { get; set; }

		// public int ProgressId { get; set; }
       
       // public Progress Progress { get; set; }
    }
}
