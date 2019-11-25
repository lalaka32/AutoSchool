using Common.Entities;

namespace DataService.Services.Interfaces
{
    public interface IAutoSchoolEmployeeService
    {
        AutoSchoolEmployee[] GetBySchoolId(int schoolId);

        void Create(AutoSchoolEmployee employee);
    }
}