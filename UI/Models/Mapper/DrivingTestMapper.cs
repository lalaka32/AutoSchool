using AutoMapper;
using Common.DataContracts.DrivingTest;
using UI.Models.DrivingTest;

namespace UI.Models.Mapper
{
    public class DrivingTestWebMappingProfile : Profile
    {
        public DrivingTestWebMappingProfile()
        {
            CreateMap<DrivingTestCollectionItemDto, DrivingTestCollectionItemModel>();
        }
    }
}
