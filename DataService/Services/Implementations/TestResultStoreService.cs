using Common.Entities;
using DataService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Services.Implementations
{
	public class TestResultStoreService : ITestResultStoreService
	{
		readonly AutoSchoolContext storeContext;

		public TestResultStoreService(AutoSchoolContext storeContext)
		{
			this.storeContext = storeContext;
		}

		public void AddTestResult(TestResult testResult)
		{
			storeContext.TestResults.Add(testResult);
			storeContext.SaveChanges();
		}
	}
}
