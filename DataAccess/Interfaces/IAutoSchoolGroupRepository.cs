using Common.Entities;

namespace DataAccess.Interfaces
{
    public interface IAutoSchoolGroupRepository
    {
        AutoClassGroup[] GetBySchoolId(int schoolId);

        void Create(AutoClassGroup @group);
    }
}