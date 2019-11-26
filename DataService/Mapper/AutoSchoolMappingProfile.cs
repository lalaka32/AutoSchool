using AutoMapper;
using Common.BusinessObjects;
using Common.DataContracts.AutoSchool;

namespace DataService.Mapper
{
    public class AutoSchoolMappingProfile : Profile
    {
        public AutoSchoolMappingProfile()
        {
            CreateMap<AutoSchool, AutoSchoolCollectionItemDto>();
            
            CreateMap<AutoSchool, AutoSchoolCollectionItemDto>();
            
        }
    }
}