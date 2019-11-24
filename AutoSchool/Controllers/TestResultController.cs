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
        readonly IAuthenticationService _authenticationService;

        public TestResultController(IDrivingTestService testResultStoreService, IMapper mapper,
            IAuthenticationService authenticationService)
        {
            _drivingTestService = testResultStoreService;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        [HttpPost("[action]")]
        public IActionResult Post([FromBody] DrivingTestCreateModel testResult)
        {
            _drivingTestService.CreateCrossTest(_mapper.Map<DrivingTestCreateDto>(testResult));
            return Ok();
        }

        [HttpGet("[action]")]
        public IEnumerable<DrivingTestCollectionItemDto> GetAllByUser()
        {
            var dtos = _drivingTestService.GetUserHistory(new DrivingTestCollectionFilterDto
            {
                UserId = _authenticationService.GetCurrentUserId()
            });
            return dtos;
        }
    }
}