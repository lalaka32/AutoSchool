using AutoMapper;
using Common.DataContracts.AutoSchool;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.AutoSchool;

namespace UI.Pages.AutoSchool
{
    public class Create : PageModel
    {
        private readonly IAutoSchoolService _autoSchoolService;
        private readonly IMapper _mapper;
        [BindProperty] public AutoSchoolModel AutoSchool { get; set; }
        
        public Create(IAutoSchoolService autoSchoolService, IMapper mapper)
        {
            _autoSchoolService = autoSchoolService;
            _mapper = mapper;
        }
        
        public void OnGet()
        {
            AutoSchool = new AutoSchoolModel();
        }
        
        public IActionResult OnPost()
        {
            _autoSchoolService.Create(_mapper.Map<AutoSchoolCreateDto>(AutoSchool));
            return RedirectToPage("Index");
        }
    }
}