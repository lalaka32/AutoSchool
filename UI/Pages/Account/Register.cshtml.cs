using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.DataContracts.User;
using Common.Ecxeptions;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UI.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public RegisterModel(IMapper mapper, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        [BindProperty]
        public UserRegistryModel registryModel { get; set; }

        public void OnGet()
        {
           
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (registryModel.Password != registryModel.ConfirmPassword)
            {
                ModelState.AddModelError<RegisterModel>(x => x.registryModel.ConfirmPassword, "Please confirm password");
                return Page();
            }
            var userLoginDto = _mapper.Map<UserCreateDto>(registryModel);
            try
            {
                _authenticationService.SignUp(userLoginDto);
            }
            catch (BadOperationException e)
            {
                if (e.Code == ErrorCode.LoginOccupied)
                {
                    ModelState.AddModelError<RegisterModel>(x => x.registryModel.Login, "Login occupied");
                }
                return Page();
            }
            return RedirectToPage("../Index");
        }
    }
}