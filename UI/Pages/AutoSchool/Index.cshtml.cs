using AutoMapper;
using Common.DataContracts.AutoSchool;
using Common.DataContracts.User;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.AutoSchool;
using UI.Models.User;

namespace UI.Pages.AutoSchool
{
    public class Index : PageModel
    {
        private readonly IAutoSchoolService _autoSchoolService;
        private readonly IMapper _mapper;
        [BindProperty] public AutoSchoolModel[] AutoSchools { get; set; }

        public Index(IAutoSchoolService autoSchoolService, IMapper mapper)
        {
            _autoSchoolService = autoSchoolService;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var dtos = _autoSchoolService.Search(new AutoSchoolCollectionFilterDto());
            AutoSchools = _mapper.Map<AutoSchoolModel[]>(dtos);
        }
    }
}