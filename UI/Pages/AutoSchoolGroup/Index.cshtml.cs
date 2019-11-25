using AutoMapper;
using Common.DataContracts.AutoSchool;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.AutoSchool;
using UI.Models.AutoSchoolGroup;

namespace UI.Pages.AutoSchoolGroup
{
    public class Index : PageModel
    {
        private readonly IAutoSchoolGroupService _autoSchoolGroupService;
        private readonly IMapper _mapper;
        [BindProperty] public AutoSchoolGroupModel[] Groups { get; set; }
        public int AutoSchoolId { get; set; }

        public Index(IAutoSchoolGroupService autoSchoolGroupService, IMapper mapper)
        {
            _autoSchoolGroupService = autoSchoolGroupService;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var dtos = _autoSchoolGroupService.GetBySchoolId(id);
            Groups = _mapper.Map<AutoSchoolGroupModel[]>(dtos);
            AutoSchoolId = id;
        }
    }
}