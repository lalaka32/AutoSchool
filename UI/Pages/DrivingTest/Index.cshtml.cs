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

        [BindProperty]
        public DrivingTestCollectionItemModel[] testModels { get; set; }

        public IndexModel(IDrivingTestService drivingTestService, IMapper mapper)
        {
            _drivingTestService = drivingTestService;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var dtos = _drivingTestService.GetUserHistory(new DrivingTestCollectionFilterDto
            {
                UserId = 1
            });
            testModels = _mapper.Map<DrivingTestCollectionItemModel[]>(dtos);
        }
    }
}