using Common.BisnessObjects;
using Common.DataContracts.DrivingTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IDrivingTestRepository
    {
        IReadOnlyCollection<DrivingTest> Find(DrivingTestCollectionFilterDto filter);
    }
}
