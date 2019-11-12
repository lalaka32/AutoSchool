using AutoMapper;
using Common.BisnessObjects;
using Common.DataContracts.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Mapper
{
    class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserCollectionItemDto>();
            CreateMap<UserCreateDto, User>()
                .ForMember(entity => entity.RoleId,
                    opts => opts.MapFrom(dto => (int) dto.RoleId))
                .ForMember(entity => entity.Role, opts => opts.Ignore());
            //.ForMember(entity => entity.Progress, opts => opts.Ignore())
            //.ForMember(entity => entity.ProgressId, opts => opts.Ignore());
        }
    }
}