using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.DataContracts.User;
using Common.Ecxeptions;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.User;

namespace UI.Pages.User
{
    public class LoginModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ICookieAuthenticationService _authenticationService;

        public LoginModel(IMapper mapper, ICookieAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        [BindProperty]
        public UserLoginModel loginModel { get; set; }

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
            return RedirectToPage("../Index");
        }
    }
}