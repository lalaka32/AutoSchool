using System.Collections.Generic;
using Common.DataContracts.AutoSchoolGroup;
using Common.Entities;

namespace DataService.Services.Interfaces
{
    public interface IAutoSchoolGroupService
    {
        AutoClassGroup[] GetBySchoolId(int schoolId);

        void Create(AutoClassGroup classGroup);
        IReadOnlyCollection<AutoSchoolGroupCollectionItemDto> Search(AutoSchoolGroupCollectionFilterDto filter);
    }
}