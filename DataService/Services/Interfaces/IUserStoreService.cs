using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Services.Interfaces
{
	public interface IUserStoreService
	{
		void AddUser(User user);
	}
}
