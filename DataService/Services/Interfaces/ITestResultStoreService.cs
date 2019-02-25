using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Services.Interfaces
{
	public interface ITestResultStoreService
	{
		void AddTestResult(TestResult testResult);
	}
}
