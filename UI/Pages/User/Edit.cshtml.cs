using AutoMapper;
using Common.DataContracts.User;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.User;

namespace UI.Pages.User
{
    public class Edit : PageModel
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        [BindProperty] public UserModel userModel { get; set; }

        public RoleModel[] roles { get; set; }

        public Edit(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var dto = _userService.Get(id);
            userModel = _mapper.Map<UserModel>(dto);
            roles = _mapper.Map<RoleModel[]>(_userService.GetAllRoles());
        }

        public IActionResult OnPost()
        {
            _userService.Update(_mapper.Map<UserDto>(userModel));
            return RedirectToPage("Index");
        }
    }
}