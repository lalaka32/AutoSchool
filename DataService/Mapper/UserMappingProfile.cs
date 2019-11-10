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
        }
    }
}
