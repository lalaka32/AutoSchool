using AutoMapper;
using Common.DataContracts.DrivingTest;
using System;
using System.Collections.Generic;
using System.Text;
using Common.BusinessObjects;

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
