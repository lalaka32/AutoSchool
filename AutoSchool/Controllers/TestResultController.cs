using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoSchool.Models;
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
		readonly IMapper _mapper;

        public TestResultController(IDrivingTestService testResultStoreService, IMapper mapper)
		{
            _drivingTestService = testResultStoreService;
            _mapper = mapper;
		}

		[HttpPost("[action]")]
		public IActionResult Post([FromBody]DrivingTestCreateModel testResult)
		{
			_drivingTestService.CreateCrossTest(_mapper.Map<DrivingTestCreateDto>(testResult));
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