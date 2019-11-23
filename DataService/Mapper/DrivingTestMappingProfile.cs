using AutoMapper;
using Common.DataContracts.DrivingTest;
using System;
using System.Collections.Generic;
using System.Text;
using Common.BusinessObjects;
using Common.Entities;

namespace DataService.Mapper
{
    public class DrivingTestMappingProfile : Profile
    {
        public DrivingTestMappingProfile()
        {
            CreateMap<DrivingTest, DrivingTestCollectionItemDto>();

            CreateMap<DrivingTestCreateDto, DrivingTest>()
                .ForMember(entity => entity.Id, opts => opts.Ignore())
                .ForMember(entity => entity.User, opts => opts.Ignore())
                .ForMember(entity => entity.UserId, opts => opts.Ignore())
                .ForMember(entity => entity.AddedAt, opts => opts.Ignore())
                .ForMember(entity => entity.UpdatedAt, opts => opts.Ignore())
                .ForMember(entity => entity.RuleSection, opts => opts.Ignore());
            
            CreateMap<RoadSituationCreateDto, RoadSituation>()
                .ForMember(entity => entity.Id, opts => opts.Ignore())
                .ForMember(entity => entity.DrivingTest, opts => opts.Ignore())
                .ForMember(entity => entity.DrivingTestId, opts => opts.Ignore());
        }
    }
}