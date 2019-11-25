using System.Linq;
using Common.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class AutoSchoolEmployeeRepository : IAutoSchoolEmployeeRepository
    {
        private readonly AutoSchoolContext _context;

        public AutoSchoolEmployeeRepository(AutoSchoolContext context)
        {
            _context = context;
        }
        
        public AutoSchoolEmployee[] GetBySchoolId(int autoSchoolId)
        {
            return _context.AutoSchoolEmployees
                .Include(x => x.Lecturer)
                .Include(x => x.AutoSchool)
                .AsNoTracking()
                .Where(x => x.AutoSchoolId == autoSchoolId)
                .ToArray();
        }

        public void Create(AutoSchoolEmployee admin)
        {
            _context.AutoSchoolEmployees.Add(new AutoSchoolEmployee
            {
                LecturerId = admin.LecturerId,
                AutoSchoolId = admin.AutoSchoolId
            });
            _context.SaveChanges();
        }
    }
}