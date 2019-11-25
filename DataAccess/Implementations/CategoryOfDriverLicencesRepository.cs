using System.Linq;
using Common.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class CategoryOfDriverLicencesRepository : ICategoryOfDriverLicencesRepository
    {
        private readonly AutoSchoolContext _context;

        public CategoryOfDriverLicencesRepository(AutoSchoolContext context)
        {
            _context = context;
        }

        public CategoryOfDriverLicence[] GetAll()
        {
            return _context.CategoryOfDriverLicences.AsNoTracking().ToArray();
        }
    }
}