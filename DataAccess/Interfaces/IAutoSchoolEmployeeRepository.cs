using Common.Entities;

namespace DataAccess.Interfaces
{
    public interface IAutoSchoolEmployeeRepository
    {
        AutoSchoolEmployee[] GetBySchoolId(int autoSchoolId);
        void Create(AutoSchoolEmployee admin);
    }
}