using Common.Entities;
using DataService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Services.Implementations
{
	public class UserStoreService : IUserStoreService
	{
		readonly AutoSchoolContext storeContext;

		public UserStoreService(AutoSchoolContext storeContext)
		{
			this.storeContext = storeContext;
		}

		public void AddUser(User user)
		{
			storeContext.Add(user);
			storeContext.SaveChanges();
		}
	}
}
