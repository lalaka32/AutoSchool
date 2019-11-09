using DataAccess.Implementations;
using DataService.Services.Implementations;
using DataService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common.MiddleWare.Extentions
{
    public static class DependencyInjectionBootstrappingExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            IApplicationComponentSearchService typeScannerService = new ApplicationComponentSearchService();

            var assemblies = new List<Assembly>
            {
                typeof(DrivingTestService).Assembly
            };

            RegisterServices(
                services,
                typeScannerService.FindServiceImplementations(assemblies, "Service"));
        }

        public static void AddDataAccess(this IServiceCollection services)
        {
            IApplicationComponentSearchService typeScannerService = new ApplicationComponentSearchService();

            var assemblies = new List<Assembly>
            {
                typeof(DrivingTestRepository).Assembly,
            };

            RegisterServices(
                services,
                typeScannerService.FindServiceImplementations(assemblies, "Repository"));
        }

        private static void RegisterServices(
            IServiceCollection services,
            IEnumerable<(Type serviceType, Type implementationType)> serviceImplementations)
        {
            foreach (var serviceImplementation in serviceImplementations)
            {
                services.TryAdd(
                    new ServiceDescriptor(
                        serviceImplementation.serviceType,
                        serviceImplementation.implementationType,
                        ServiceLifetime.Scoped));
            }
        }
    }
}
