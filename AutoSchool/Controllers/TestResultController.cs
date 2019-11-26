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
using AutoSchool.Models.Driving_Test;

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

        [HttpGet("[action]/{id}")]
        public DrivingTestModel Get(int id)
        {
            var dto = _drivingTestService.GetTest(id);
            return _mapper.Map<DrivingTestModel>(dto);
        }

        //[HttpGet("[action]/{id}")]
        //public IEnumerable<RoadSituationCollectionItemModel> GetTestRoadSituations(int id)
        //{
        //    var dto = _drivingTestService.GetTest(id);
        //    return _mapper.Map<DrivingTestModel>(dto);
        //}

        [HttpGet("[action]")]
        public IEnumerable<DrivingTestCollectionItemModel> GetAllByUser()
        {
            var dtos = _drivingTestService.GetUserHistory(new DrivingTestCollectionFilterDto
            {
                UserId = _authenticationService.GetCurrentUserId()
            });
            return _mapper.Map<IEnumerable<DrivingTestCollectionItemModel>>(dtos);
        }
    }
}