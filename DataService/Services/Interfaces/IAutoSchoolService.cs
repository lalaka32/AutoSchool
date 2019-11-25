using System.Collections.Generic;
using Common.DataContracts.AutoSchool;

namespace DataService.Services.Interfaces
{
    public interface IAutoSchoolService
    {
        int Create(AutoSchoolCreateDto dto);
        
        AutoSchoolDto Get(int id);

        IReadOnlyCollection<AutoSchoolCollectionItemDto> Search(AutoSchoolCollectionFilterDto filter);
    }
}