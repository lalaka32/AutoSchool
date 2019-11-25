using System.Collections.Generic;
using AutoMapper;
using Common.DataContracts.AutoSchool;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;

namespace DataService.Services.Implementations
{
    public class AutoSchoolService : IAutoSchoolService
    {
        private readonly IAutoSchoolRepository _repository;
        private readonly IMapper _mapper;

        public AutoSchoolService(IAutoSchoolRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int Create(AutoSchoolCreateDto dto)
        {
            return _repository.Create(dto);
        }

        public AutoSchoolDto Get(int id)
        {
            return _mapper.Map<AutoSchoolDto>(_repository.Get(id));
        }

        public IReadOnlyCollection<AutoSchoolCollectionItemDto> Search(AutoSchoolCollectionFilterDto filter)
        {
            var result = _repository.Search(filter);
            return _mapper.Map<IReadOnlyCollection<AutoSchoolCollectionItemDto>>(result);
        }
    }
}