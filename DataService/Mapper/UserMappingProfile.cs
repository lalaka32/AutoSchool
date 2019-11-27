using AutoMapper;
using Common.DataContracts.User;
using System;
using System.Collections.Generic;
using System.Text;
using Common.BusinessObjects;
using Common.Enums.User;

namespace DataService.Mapper
{
    class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserCollectionItemDto>()
                .ForMember(entity => entity.RoleName,
                    opts => opts.MapFrom(dto => dto.Role.Name));
            CreateMap<User, UserDto>()
                .ForMember(entity => entity.Role,
                    opts => opts.MapFrom(dto => (Role) dto.RoleId));
            CreateMap<UserCreateDto, User>()
                .ForMember(entity => entity.RoleId,
                    opts => opts.MapFrom(dto => (int) dto.RoleId))
                .ForMember(entity => entity.Role, opts => opts.Ignore())
                .ForMember(entity => entity.Key, opts => opts.Ignore())
                .ForMember(entity => entity.Name, opts => opts.Ignore())
                .ForMember(entity => entity.Email, opts => opts.Ignore())
                .ForMember(entity => entity.Password, opts => opts.Ignore())
                .ForMember(entity => entity.Address, opts => opts.Ignore())
                .ForMember(entity => entity.PhoneNumber, opts => opts.Ignore());
            //.ForMember(entity => entity.Progress, opts => opts.Ignore())
            //.ForMember(entity => entity.ProgressId, opts => opts.Ignore());
            CreateMap<Common.Entities.Role, RoleDto>();
        }
    }
}