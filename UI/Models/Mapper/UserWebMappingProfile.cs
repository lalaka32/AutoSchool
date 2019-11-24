using AutoMapper;
using Common.DataContracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums.User;
using UI.Models.User;

namespace UI.Models.Mapper
{
    public class UserWebMappingProfile : Profile
    {
        public UserWebMappingProfile()
        {
            CreateMap<UserLoginModel, UserLoginDto>();

            CreateMap<UserRegistryModel, UserCreateDto>()
                .ForMember(dto => dto.RoleId, options => options.Ignore());

            CreateMap<UserRegistryModel, UserLoginDto>();

            CreateMap<UserCollectionItemDto, UserCollectionItemModel>();

            CreateMap<UserDto, UserModel>()
                .ForMember(model => model.RoleId, options => options.MapFrom(dto => (int) dto.Role));

            CreateMap<UserModel, UserDto>()
                .ForMember(model => model.Role, options => options.MapFrom(dto => (Role) dto.RoleId));

            CreateMap<RoleDto, RoleModel>();
        }
    }
}