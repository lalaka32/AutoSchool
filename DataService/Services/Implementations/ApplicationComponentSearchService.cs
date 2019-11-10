using DataService.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DataService.Services.Implementations
{
    public class ApplicationComponentSearchService : IApplicationComponentSearchService
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<(Type serviceType, Type implementationType)> FindServiceImplementations(IEnumerable<Assembly> targetAssemblies, string serviceNamePostfix)
        {
            if (string.IsNullOrWhiteSpace(serviceNamePostfix))
            {
                throw new ArgumentException("Postfix should not be empty");
            }

            var assemblies = targetAssemblies != null
                ? targetAssemblies.ToArray()
                : throw new ArgumentNullException("targetAssemblies is null");

            if (!assemblies.Any())
            {
                throw new ArgumentException("targetAssemblies should not be empty");
            }

            var serviceImplementations = new List<(Type serviceType, Type implementationType)>();

            foreach (var targetAssembly in assemblies)
            {
                var implementationTypes = targetAssembly.GetExportedTypes()
                    .Where(
                        t => t.IsClass
                             && !t.IsAbstract
                             && !t.IsGenericType
                             && !t.IsNested
                             && t.Name.EndsWith(serviceNamePostfix))
                    .ToList();

                foreach (var implementationType in implementationTypes)
                {
                    var serviceTypes = implementationType.GetTypeInfo()
                        .ImplementedInterfaces
                        .Where(i => i != typeof(IDisposable) && i.IsPublic)
                        .ToList();

                    if (serviceTypes.Count == 0)
                    {
                        serviceImplementations.Add((implementationType, implementationType));
                    }

                    //Exclude IHostedService as it should be singleton
                    if (serviceTypes.Contains(typeof(IHostedService)))
                    {
                        continue;
                    }

                    foreach (var serviceType in serviceTypes)
                    {
                        serviceImplementations.Add((serviceType, implementationType));
                    }
                }
            }

            return serviceImplementations.AsReadOnly();
        }
    }
}
