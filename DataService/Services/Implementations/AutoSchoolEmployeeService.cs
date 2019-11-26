using Common.Entities;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;

namespace DataService.Services.Implementations
{
    public class AutoSchoolEmployeeService : IAutoSchoolEmployeeService
    {
        private readonly IAutoSchoolEmployeeRepository _autoSchoolEmployeeRepository;
        
        public AutoSchoolEmployeeService(IAutoSchoolEmployeeRepository autoSchoolEmployeeRepository)
        {
            _autoSchoolEmployeeRepository = autoSchoolEmployeeRepository;
        }
        public AutoSchoolEmployee[] GetBySchoolId(int schoolId)
        {
            return _autoSchoolEmployeeRepository.GetBySchoolId(schoolId);
        }

        public void Create(AutoSchoolEmployee employee)
        {
            _autoSchoolEmployeeRepository.Create(employee);
        }
    }
}