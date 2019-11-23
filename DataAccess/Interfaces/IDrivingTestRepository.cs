using Common.DataContracts.DrivingTest;
using System;
using System.Collections.Generic;
using System.Text;
using Common.BusinessObjects;

namespace DataAccess.Interfaces
{
    public interface IDrivingTestRepository
    {
        IReadOnlyCollection<DrivingTest> Find(DrivingTestCollectionFilterDto filter);
        
        int Create(DrivingTest entity);
    }
}
