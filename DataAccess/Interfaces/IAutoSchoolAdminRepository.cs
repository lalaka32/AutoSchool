using Common.Entities;

namespace DataAccess.Interfaces
{
    public interface IAutoSchoolAdminRepository
    {
        AutoSchoolAdmin[] GetBySchoolId(int autoSchoolId);
        void Create(AutoSchoolAdmin admin);
    }
}