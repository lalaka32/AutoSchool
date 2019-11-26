using AutoMapper;
using Common.DataContracts.AutoSchool;
using Common.DataContracts.User;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.AutoSchool;
using UI.Models.User;

namespace UI.Pages.AutoSchoolEmployee
{
    public class Create : PageModel
    {
        private readonly IUserService _userService;
        private readonly IAutoSchoolEmployeeService _autoSchoolAdminService;
        private readonly IMapper _mapper;
        [BindProperty] public int AutoSchoolId { get; set; }
        public UserCollectionItemModel[] UserModels { get; set; }

        [BindProperty] public int SelectedUserId { get; set; }

        public Create(IUserService userService, IMapper mapper, IAutoSchoolEmployeeService autoSchoolAdminService)
        {
            _userService = userService;
            _mapper = mapper;
            _autoSchoolAdminService = autoSchoolAdminService;
        }

        public void OnGet(int id)
        {
            var dtos = _userService.Search(new UserCollectionFilterDto());
            UserModels = _mapper.Map<UserCollectionItemModel[]>(dtos);
            AutoSchoolId = id;
        }

        public IActionResult OnPost()
        {
            _autoSchoolAdminService.Create(
                new Common.Entities.AutoSchoolEmployee()
                {
                    LecturerId = SelectedUserId,
                    AutoSchoolId = AutoSchoolId
                });
            return RedirectToPage("Index", new {id = AutoSchoolId});
        }
    }
}