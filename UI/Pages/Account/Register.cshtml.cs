using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.DataContracts.User;
using Common.Ecxeptions;
using Common.Enums.User;
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
        private readonly ICookieAuthenticationService _authenticationService;
        private readonly IUserService _userService;

        public RegisterModel(IMapper mapper, ICookieAuthenticationService authenticationService,
            IUserService userService)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [BindProperty] public UserRegistryModel registryModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (registryModel.Password != registryModel.ConfirmPassword)
            {
                ModelState.AddModelError<RegisterModel>(x => x.registryModel.ConfirmPassword,
                    "Please confirm password");
                return Page();
            }

            var userCreateDto = _mapper.Map<UserCreateDto>(registryModel);
            userCreateDto.RoleId = Role.Administrator;
            try
            {
                _userService.Create(userCreateDto);
                await _authenticationService.Login(_mapper.Map<UserLoginDto>(registryModel));
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