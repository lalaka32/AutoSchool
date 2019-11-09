using AutoMapper;
using Common.DataContracts.DrivingTest;
using UI.Models.DrivingTest;

namespace UI.Models.Mapper
{
    public class DrivingTestMapper : Profile
    {
        public DrivingTestMapper()
        {
            CreateMap<DrivingTestCollectionItemDto, DrivingTestCollectionItemModel>();
        }
    }
}
