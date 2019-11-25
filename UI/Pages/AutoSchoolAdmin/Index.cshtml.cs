using AutoMapper;
using Common.DataContracts.User;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.User;

namespace UI.Pages.AutoSchoolAdmin
{
    public class Index : PageModel
    {
        private readonly IAutoSchoolAdminService _schoolAdminService;
        private readonly IMapper _mapper;
        [BindProperty] public AutoSchoolAdminModel[] AutoSchoolAdminModels { get; set; }
        public int AutoSchoolId { get; set; }

        public Index(IAutoSchoolAdminService schoolAdminService, IMapper mapper)
        {
            _schoolAdminService = schoolAdminService;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var dtos = _schoolAdminService.GetBySchoolId(id);
            AutoSchoolAdminModels = _mapper.Map<AutoSchoolAdminModel[]>(dtos);
            AutoSchoolId = id;
        }
    }
}