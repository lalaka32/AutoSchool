using AutoMapper;
using Common.DataContracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }
    }
}