using Common.Entities;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;

namespace DataService.Services.Implementations
{
    public class AutoSchoolAdminService : IAutoSchoolAdminService
    {
        private readonly IAutoSchoolAdminRepository _autoSchoolAdminRepository;
        
        public AutoSchoolAdminService(IAutoSchoolAdminRepository autoSchoolAdminRepository)
        {
            _autoSchoolAdminRepository = autoSchoolAdminRepository;
        }
        public AutoSchoolAdmin[] GetBySchoolId(int schoolId)
        {
            return _autoSchoolAdminRepository.GetBySchoolId(schoolId);
        }

        public void Create(AutoSchoolAdmin admin)
        {
            _autoSchoolAdminRepository.Create(admin);
        }
    }
}