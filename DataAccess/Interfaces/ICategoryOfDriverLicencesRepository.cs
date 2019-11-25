using Common.Entities;

namespace DataAccess.Interfaces
{
    public interface ICategoryOfDriverLicencesRepository
    {
        CategoryOfDriverLicence[] GetAll();
    }
}