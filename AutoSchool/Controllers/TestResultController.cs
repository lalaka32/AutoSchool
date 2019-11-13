using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DataContracts.DrivingTest;
using Common.BusinessObjects;
using Common.Entities;
using DataService.Services.Implementations;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultController : ControllerBase
    {
		readonly IDrivingTestService _drivingTestService;

        public TestResultController(IDrivingTestService testResultStoreService)
		{
            _drivingTestService = testResultStoreService;
		}

		[HttpPost("[action]")]
		public IActionResult Post([FromBody]DrivingTest testResult)
		{
			//testResultStoreService.AddTestResult(testResult);
			//userStoreService.AddUser(user);
			return Ok();
		}

        [HttpGet("[action]")]
        public IEnumerable<DrivingTestCollectionItemDto> GetAllByUser()
        {
            var dtos = _drivingTestService.GetUserHistory(new DrivingTestCollectionFilterDto
            {
                UserId = 4
            });
            return dtos;
        }
    }
}