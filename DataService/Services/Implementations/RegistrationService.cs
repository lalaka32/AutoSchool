using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.BisnessObjects;
using Common.Entities;
using DataAccess;
using DataService.Services.Interfaces;

namespace DataService.Services.Implementations
{
    public class RegistrationService 
    {
        public RegistrationService(AutoSchoolContext context)
        {
            this.context = context;
        }

        private readonly AutoSchoolContext context;

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpgradeToAdmin(User user)
        {
            throw new NotImplementedException();
        }

        public void UpgradeToLecturer(User user)
        {
            throw new NotImplementedException();
        }

        public bool UserWithLoginExist(string userLogin)
        {
            return context.Users.FirstOrDefault(x => x.Login == userLogin) != null;
        }

        public User GetUserByLogin(string userLogin)
        {
            return context.Users.FirstOrDefault(x => x.Login == userLogin);
        }
    }
}
