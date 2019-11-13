using AutoMapper;
using Common.DataContracts.DrivingTest;
using Common.Entities;
using DataAccess;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Services.Implementations
{
	public class DrivingTestService : IDrivingTestService
	{
		private readonly IDrivingTestRepository _drivingTestRepository;
        private readonly IMapper _mapper;


        public DrivingTestService(IDrivingTestRepository drivingTestRepository, IMapper mapper)
		{
            _drivingTestRepository = drivingTestRepository;
            _mapper = mapper;

        }

        public IReadOnlyCollection<DrivingTestCollectionItemDto> GetUserHistory(DrivingTestCollectionFilterDto filter)
        {
            var result = _drivingTestRepository.Find(filter);
            var mappedResult = _mapper.Map<IReadOnlyCollection<DrivingTestCollectionItemDto>>(result);
            return mappedResult;
        }
    }
}
