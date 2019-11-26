using Common.Entities;

namespace DataService.Services.Interfaces
{
    public interface IAutoSchoolAdminService
    {
        AutoSchoolAdmin[] GetBySchoolId(int schoolId);
        void Create(AutoSchoolAdmin admin);
    }
}