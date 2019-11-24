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

        public int Create(UserCreateDto dto)
        {
            var entity = _mapper.Map<User>(dto);
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
    }
}