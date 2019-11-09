using Common.DataContracts.DrivingTest;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Services.Interfaces
{
    // TODO: Split dtos and entities. Add reference only for dtos
	public interface IDrivingTestService
	{
        IReadOnlyCollection<DrivingTestCollectionItemDto> GetUserHistory(DrivingTestCollectionFilterDto filter);
	}
}
