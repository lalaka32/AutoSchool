using System.Collections.Generic;
using System.Linq;
using Common.BusinessObjects;
using Common.DataContracts.AutoSchool;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class AutoSchoolRepository : IAutoSchoolRepository
    {
        private readonly AutoSchoolContext _context;

        public AutoSchoolRepository(AutoSchoolContext context)
        {
            _context = context;
        }

        public int Create(AutoSchoolCreateDto dto)
        {
            var entity = new AutoSchool()
            {
                Name = dto.Name
            };
            _context.AutoSchools.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public AutoSchool Get(int id)
        {
            return _context.AutoSchools
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);
        }

        public IReadOnlyCollection<AutoSchool> Search(AutoSchoolCollectionFilterDto filter)
        {
            return _context.AutoSchools
                .AsNoTracking()
                .ToList()
                .AsReadOnly();
        }
    }
}