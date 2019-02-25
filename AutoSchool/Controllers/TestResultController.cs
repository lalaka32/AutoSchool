using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;
using DataService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultController : ControllerBase
    {
		readonly ITestResultStoreService testResultStoreService;

		public TestResultController(ITestResultStoreService testResultStoreService)
		{
			this.testResultStoreService = testResultStoreService;
		}

		[HttpPost("[action]")]
		public IActionResult Post([FromBody]TestResult testResult)
		{
			testResultStoreService.AddTestResult(testResult);
			//userStoreService.AddUser(user);
			return Ok();
		}
    }
}