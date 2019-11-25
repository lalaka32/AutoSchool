using System;
using System.Linq;
using Common.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class AutoSchoolGroupRepository : IAutoSchoolGroupRepository
    {
        private readonly AutoSchoolContext _context;

        public AutoSchoolGroupRepository(AutoSchoolContext context)
        {
            _context = context;
        }
        
        public AutoClassGroup[] GetBySchoolId(int schoolId)
        {
            return _context.AutoClassGroups
                .Include(x => x.Lecturer)
                .Include(x => x.CategoryOfDriverLicence)
                .AsNoTracking()
                .Where(x => x.Lecturer.AutoSchoolId == schoolId)
                .ToArray();
        }

        public void Create(AutoClassGroup group)
        {
            _context.AutoClassGroups.Add(new AutoClassGroup
            {
                LecturerId = group.LecturerId,
                Name = group.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CategoryOfDriverLicenceId = group.CategoryOfDriverLicenceId
            });
            _context.SaveChanges();
        }
    }
}