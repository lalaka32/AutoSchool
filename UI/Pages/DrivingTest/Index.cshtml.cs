using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.DrivingTest;
using Common.DataContracts.DrivingTest;
using AutoMapper;

namespace UI.Pages.DrivingTest
{
    public class IndexModel : PageModel
    {
        private readonly IDrivingTestService _drivingTestService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        [BindProperty] public DrivingTestCollectionItemModel[] TestModels { get; set; }

        public IndexModel(IDrivingTestService drivingTestService, IMapper mapper, IUserService userService)
        {
            _drivingTestService = drivingTestService;
            _mapper = mapper;
            _userService = userService;
        }

        public void OnGet()
        {
            var currentUser = _userService.GetCurrentUser();
            var dtos = _drivingTestService.GetUserHistory(new DrivingTestCollectionFilterDto
            {
                UserId = currentUser.Id
            });
            TestModels = _mapper.Map<DrivingTestCollectionItemModel[]>(dtos);
        }
    }
}