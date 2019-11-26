using Common.DataContracts.DrivingTest;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Common.BusinessObjects;
using Common.Entities;

namespace DataAccess.Implementations
{
    public class DrivingTestRepository : IDrivingTestRepository
    {
        private readonly AutoSchoolContext _context;

        public DrivingTestRepository(AutoSchoolContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<DrivingTest> Find(DrivingTestCollectionFilterDto filter)
        {
            var result = _context.DrivingTests
                .Skip(filter.Skip)
                .Take(filter.Take)
                .Where(x => x.UserId == filter.UserId)
                .OrderBy(x => x.UpdatedAt)
                .AsNoTracking()
                .ToList();
            return result.AsReadOnly();
        }

        public DrivingTest Get(int i)
        {
            var result = _context.DrivingTests.Include(x => x.RoadSituations).Include(x => x.RuleSection).AsNoTracking().
                FirstOrDefault(x => x.Id == i);
            return result;
        }

        public int Create(DrivingTest entity)
        {
            _context.DrivingTests.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }
    }
}