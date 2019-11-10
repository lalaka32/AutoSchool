using Common.BisnessObjects;
using Common.DataContracts.DrivingTest;
using Common.DataContracts.User;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AutoSchoolContext _context;

        public UserRepository(AutoSchoolContext context)
        {
            _context = context;
        }
        public int Create(UserCreateDto dto)
        {
            var entity = new User
            {
                Login = dto.Login,
                Password = dto.Password,
                RoleId = dto.RoleId
            };
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public IReadOnlyCollection<User> Search(UserCollectionFilterDto filter)
        {
            return _context.Users
                .Where(u => (filter.Login == null || u.Login == filter.Login))
                .AsNoTracking()
                .ToList()
                .AsReadOnly();
        }
    }
}
