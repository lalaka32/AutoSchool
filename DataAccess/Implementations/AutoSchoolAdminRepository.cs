using System.Linq;
using Common.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class AutoSchoolAdminRepository : IAutoSchoolAdminRepository
    {
        private readonly AutoSchoolContext _context;

        public AutoSchoolAdminRepository(AutoSchoolContext context)
        {
            _context = context;
        }

        public AutoSchoolAdmin[] GetBySchoolId(int autoSchoolId)
        {
            return _context.AutoSchoolAdmins
                .Include(x => x.Admin)
                .Include(x => x.AutoSchool)
                .AsNoTracking()
                .Where(x => x.AutoSchoolId == autoSchoolId)
                .ToArray();
        }

        public void Create(AutoSchoolAdmin admin)
        {
            _context.AutoSchoolAdmins.Add(new AutoSchoolAdmin
            {
                AdminId = admin.AdminId,
                AutoSchoolId = admin.AutoSchoolId
            });
            _context.SaveChanges();
        }
    }
}