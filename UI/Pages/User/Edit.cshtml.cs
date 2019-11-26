using AutoMapper;
using Common.DataContracts.AutoSchoolGroup;
using Common.DataContracts.User;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.AutoSchoolGroup;
using UI.Models.User;

namespace UI.Pages.User
{
    public class Edit : PageModel
    {
        private readonly IUserService _userService;
        private readonly IAutoSchoolGroupService _autoSchoolGroupService;
        private readonly IMapper _mapper;
        [BindProperty] public UserEditModel userModel { get; set; }

        public RoleModel[] roles { get; set; }
        
        public AutoSchoolGroupModel[] Groups { get; set; }

        public Edit(IUserService userService, IMapper mapper, IAutoSchoolGroupService autoSchoolGroupService)
        {
            _userService = userService;
            _mapper = mapper;
            _autoSchoolGroupService = autoSchoolGroupService;
        }

        public void OnGet(int id)
        {
            var dto = _userService.Get(id);
            userModel = _mapper.Map<UserEditModel>(dto);
            roles = _mapper.Map<RoleModel[]>(_userService.GetAllRoles());
            if (userModel.GroupId != null)
            {
                Groups = GetGroups(userModel.AutoSchoolId.Value);
            }
        }

        public IActionResult OnPost()
        {
            _userService.Update(_mapper.Map<UserUpdateDto>(userModel));
            return RedirectToPage("Index");
        }
        
        public AutoSchoolGroupModel[] OnGetGroups(int schoolId)
        {
            return GetGroups(schoolId);
        }

        private AutoSchoolGroupModel[] GetGroups(int schoolId)
        {
            var dtos = _autoSchoolGroupService.Search(new AutoSchoolGroupCollectionFilterDto()
            {
                AutoSchoolId = schoolId
            });
            return _mapper.Map<AutoSchoolGroupModel[]>(dtos);
        }
    }
}