using System;
using System.Collections.Generic;
using System.Text;
using Common.BisnessObjects;
using Common.Entities;

namespace DataService.Services.Interfaces
{
    public interface IRegistrationService
    {
        void AddUser(User user);

        void UpgradeToAdmin(User user);

        void UpgradeToLecturer(User user);

        bool UserWithLoginExist(string userLogin);

        User GetUserByLogin(string userLogin);
    }
}
