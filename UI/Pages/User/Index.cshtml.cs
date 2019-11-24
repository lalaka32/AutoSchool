using System.Linq;
using AutoMapper;
using Common.DataContracts.User;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.User;

namespace UI.Pages.User
{
    public class Index : PageModel
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        [BindProperty] public UserCollectionItemModel[] UserModels { get; set; }

        public Index(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var dtos = _userService.Search(new UserCollectionFilterDto());
            UserModels = _mapper.Map<UserCollectionItemModel[]>(dtos);
        }
    }
}