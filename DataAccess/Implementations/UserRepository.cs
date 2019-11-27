using Common.DataContracts.DrivingTest;
using Common.DataContracts.User;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Common.BusinessObjects;
using Common.Entities;

namespace DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AutoSchoolContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AutoSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public IReadOnlyCollection<User> Search(UserCollectionFilterDto filter)
        {
            return _context.Users
                .Include(u => u.Role)
                .Where(u => filter.Login == null || u.Login == filter.Login)
                .Where(u => filter.ExcludeRoles == null || !filter.ExcludeRoles.Contains(u.RoleId))
                .AsNoTracking()
                .ToList()
                .AsReadOnly();
        }

        public User Get(int id)
        {
            return _context.Users
                .Include(u => u.Role)
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == id);
        }

        public IReadOnlyCollection<Role> GetRoles()
        {
            return _context.Roles
                .AsNoTracking()
                .ToList()
                .AsReadOnly();
        }

        public bool Update(UserUpdateDto userDto)
        {
            var entity = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Id == userDto.Id);
            if (entity != null)
            {
                entity.RoleId = userDto.RoleId;
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}