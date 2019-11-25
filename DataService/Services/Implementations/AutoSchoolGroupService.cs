using System.Collections.Generic;
using Common.DataContracts.AutoSchoolGroup;
using Common.Entities;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;

namespace DataService.Services.Implementations
{
    public class AutoSchoolGroupService : IAutoSchoolGroupService
    {
        private readonly IAutoSchoolGroupRepository _autoSchoolGroupRepository;

        public AutoSchoolGroupService(IAutoSchoolGroupRepository autoSchoolGroupRepository)
        {
            _autoSchoolGroupRepository = autoSchoolGroupRepository;
        }

        public AutoClassGroup[] GetBySchoolId(int schoolId)
        {
            return _autoSchoolGroupRepository.GetBySchoolId(schoolId);
        }

        public void Create(AutoClassGroup classGroup)
        {
            _autoSchoolGroupRepository.Create(classGroup);
        }

        public IReadOnlyCollection<AutoSchoolGroupCollectionItemDto> Search(AutoSchoolGroupCollectionFilterDto filter)
        {
            throw new System.NotImplementedException();
        }
    }
}