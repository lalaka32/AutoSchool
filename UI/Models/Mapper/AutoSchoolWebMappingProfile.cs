using AutoMapper;
using Common.DataContracts.AutoSchool;
using Common.Entities;
using UI.Models.AutoSchool;
using UI.Models.AutoSchoolEmployee;
using UI.Models.AutoSchoolGroup;
using UI.Models.CategoryOfDrivingLicence;
using UI.Models.User;

namespace UI.Models.Mapper
{
    public class AutoSchoolWebMappingProfile : Profile
    {
        public AutoSchoolWebMappingProfile()
        {
            CreateMap<AutoSchoolCollectionItemDto, AutoSchoolModel>();

            CreateMap<AutoSchoolModel, AutoSchoolCreateDto>();
            
            CreateMap<Common.BusinessObjects.AutoSchool, AutoSchoolModel>();
            CreateMap<AutoSchoolModel, Common.BusinessObjects.AutoSchool>();
            
            CreateMap<AutoSchoolAdmin, AutoSchoolAdminModel>();
            
            CreateMap<AutoSchoolAdminModel, AutoSchoolAdmin>()
                .ForMember(x => x.Admin, opts => opts.Ignore())
                .ForMember(x => x.AutoSchool, opts => opts.Ignore());
            
            CreateMap<Common.Entities.AutoSchoolEmployee, AutoSchoolEmployeeModel>();
            
            CreateMap<AutoSchoolEmployeeModel, Common.Entities.AutoSchoolEmployee>()
                .ForMember(x => x.Lecturer, opts => opts.Ignore())
                .ForMember(x => x.AutoSchool, opts => opts.Ignore());
            
            CreateMap<CategoryOfDriverLicence, CategoryOfDrivingLicenceModel>();
            
            CreateMap<AutoClassGroup, AutoSchoolGroupModel>()
                .ForMember(x => x.CategoryName, opts => opts.MapFrom(y => y.CategoryOfDriverLicence.Name));

            CreateMap<AutoSchoolGroupModel, AutoClassGroup>()
                .ForMember(x => x.CategoryOfDriverLicenceId, opts => opts.MapFrom(y => y.CategoryId));
        }
    }
}