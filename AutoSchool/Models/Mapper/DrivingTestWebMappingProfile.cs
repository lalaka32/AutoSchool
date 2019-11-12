using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSchool.Models.User;
using Common.DataContracts.User;

namespace AutoSchool.Models.Mapper
{
    public class DrivingTestWebMappingProfile : Profile
    {
        public DrivingTestWebMappingProfile()
        {
            CreateMap<UserLoginModel, UserLoginDto>();

            CreateMap<UserRegistryModel, UserCreateDto>()
                .ForMember(dto => dto.RoleId, options => options.Ignore());

            CreateMap<UserRegistryModel, UserLoginDto>();
        }
    }
}
