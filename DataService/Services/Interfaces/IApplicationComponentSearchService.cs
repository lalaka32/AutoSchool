using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace DataService.Services.Interfaces
{
    public interface IApplicationComponentSearchService
    {
        ReadOnlyCollection<(Type serviceType, Type implementationType)> FindServiceImplementations(
            IEnumerable<Assembly> targetAssemblies,
            string serviceNamePostfix);
    }
}
