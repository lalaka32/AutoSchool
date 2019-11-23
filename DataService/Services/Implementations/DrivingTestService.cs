using AutoMapper;
using Common.DataContracts.DrivingTest;
using Common.Entities;
using DataAccess;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Common.BusinessObjects;
using Common.Enums;
using RuleSection = Common.Entities.RuleSection;

namespace DataService.Services.Implementations
{
    public class DrivingTestService : IDrivingTestService
    {
        private readonly IDrivingTestRepository _drivingTestRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;


        public DrivingTestService(IDrivingTestRepository drivingTestRepository, IMapper mapper, IUserService userService)
        {
            _drivingTestRepository = drivingTestRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public IReadOnlyCollection<DrivingTestCollectionItemDto> GetUserHistory(DrivingTestCollectionFilterDto filter)
        {
            var result = _drivingTestRepository.Find(filter);
            var mappedResult = _mapper.Map<IReadOnlyCollection<DrivingTestCollectionItemDto>>(result);
            return mappedResult;
        }

        public int CreateCrossTest(DrivingTestCreateDto dto)
        {
            var currentUser = _userService.GetCurrentUser();
            var entity = _mapper.Map<DrivingTest>(dto);
            entity.UserId = currentUser.Id;
            entity.AddedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.RuleSection = new RuleSection()
            {
                Id = (int) Common.Enums.RuleSection.Cross
            };
            var id = _drivingTestRepository.Create(entity);
            return id;
        }
    }
}