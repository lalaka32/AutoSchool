using Common.BisnessObjects;
using Common.Entities;
using DataAccess;
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
			storeContext.Users.Add(user);

			storeContext.SaveChanges();
		}
	}
}
