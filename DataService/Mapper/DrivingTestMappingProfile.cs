using AutoMapper;
using Common.BisnessObjects;
using Common.DataContracts.DrivingTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Mapper
{
    public class DrivingTestMappingProfile : Profile
    {
        public DrivingTestMappingProfile()
        {
            CreateMap<DrivingTest, DrivingTestCollectionItemDto>();
        }
    }
}
