using AutoMapper;
using Common.DataContracts.AutoSchool;
using Common.Entities;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.AutoSchool;
using UI.Models.AutoSchoolEmployee;
using UI.Models.AutoSchoolGroup;
using UI.Models.CategoryOfDrivingLicence;

namespace UI.Pages.AutoSchoolGroup
{
    public class Create : PageModel
    {
        private readonly IAutoSchoolGroupService _autoSchoolGroupService;
        private readonly IAutoSchoolEmployeeService _autoSchoolEmployeeService;
        private readonly ICategoryOfDriverLicencesRepository _categoryOfDriverLicencesRepository;
        private readonly IMapper _mapper;
        [BindProperty]
        public int AutoSchoolId { get; set; }
        [BindProperty] public AutoSchoolGroupModel GroupModel { get; set; }
        public AutoSchoolEmployeeModel[] Lecturers { get; set; }

        public CategoryOfDrivingLicenceModel[] Categories { get; set; }

        public Create(IAutoSchoolGroupService autoSchoolGroupService, IMapper mapper,
            IAutoSchoolEmployeeService autoSchoolEmployeeService,
            ICategoryOfDriverLicencesRepository categoryOfDriverLicencesRepository)
        {
            _autoSchoolGroupService = autoSchoolGroupService;
            _mapper = mapper;
            _autoSchoolEmployeeService = autoSchoolEmployeeService;
            _categoryOfDriverLicencesRepository = categoryOfDriverLicencesRepository;
        }

        public void OnGet(int id)
        {
            GroupModel = new AutoSchoolGroupModel();
            Lecturers = _mapper.Map<AutoSchoolEmployeeModel[]>(_autoSchoolEmployeeService.GetBySchoolId(id));
            Categories = _mapper.Map<CategoryOfDrivingLicenceModel[]>(_categoryOfDriverLicencesRepository.GetAll());
            AutoSchoolId = id;
        }

        public IActionResult OnPost()
        {
            GroupModel.AutoSchoolId = AutoSchoolId;
            _autoSchoolGroupService.Create(_mapper.Map<AutoClassGroup>(GroupModel));
            return RedirectToPage("Index", new {id = AutoSchoolId});
        }
    }
}