using System.Collections.Generic;
using Common.BusinessObjects;
using Common.DataContracts.AutoSchool;

namespace DataAccess.Interfaces
{
    public interface IAutoSchoolRepository
    {
        int Create(AutoSchoolCreateDto dto);
        AutoSchool Get(int id);
        IReadOnlyCollection<AutoSchool> Search(AutoSchoolCollectionFilterDto filter);
    }
}