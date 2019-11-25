using AutoMapper;
using Common.DataContracts.AutoSchool;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.AutoSchool;
using UI.Models.AutoSchoolEmployee;

namespace UI.Pages.AutoSchoolEmployee
{
    public class Index : PageModel
    {
        private readonly IAutoSchoolEmployeeService _autoSchoolEmployeeService;
        private readonly IMapper _mapper;
        [BindProperty] public AutoSchoolEmployeeModel[] AutoSchoolEmployeeModels { get; set; }
        public int AutoSchoolId { get; set; }

        public Index(IAutoSchoolEmployeeService autoSchoolEmployeeService, IMapper mapper)
        {
            _autoSchoolEmployeeService = autoSchoolEmployeeService;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var dtos = _autoSchoolEmployeeService.GetBySchoolId(id);
            AutoSchoolEmployeeModels = _mapper.Map<AutoSchoolEmployeeModel[]>(dtos);
            AutoSchoolId = id;
        }
    }
}