using System.Threading.Tasks;
using AutoMapper;
using Common.Authorization;
using Common.DataContracts.User;
using Common.Ecxeptions;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.User;

namespace UI.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public LoginModel(IMapper mapper, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        [BindProperty] public UserLoginModel loginModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var userLoginDto = _mapper.Map<UserLoginDto>(loginModel);
            try
            {
                await _authenticationService.Login(userLoginDto);
            }
            catch (BadOperationException e)
            {
                if (e.Code == ErrorCode.WrongLogin)
                {
                    ModelState.AddModelError<LoginModel>(x => x.loginModel.Login, "Login wrong");
                }
                else if (e.Code == ErrorCode.WrongPassword)
                {
                    ModelState.AddModelError<LoginModel>(x => x.loginModel.Password, "Password wrong");
                }
                return Page();
            }
            catch (ForbiddenException e)
            {
                ModelState.AddModelError<LoginModel>(x => x.loginModel.Login, "This user have no access to this site");
                return Page();
            }

            return RedirectToPage("../Index");
        }
    }
}