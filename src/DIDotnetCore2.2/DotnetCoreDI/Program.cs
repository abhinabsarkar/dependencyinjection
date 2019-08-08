using DotnetCoreDI.Interfaces;
using DotnetCoreDI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotnetCoreDI
{
    class Program
    {
        private static IServiceProvider _serviceProvider;              

        static async Task Main(string[] args)
        {
            string commandString = string.Empty;
            Console.ForegroundColor = ConsoleColor.White;

            //Register the dependencies
            RegisterServices();

            //var messageLoggerService = _serviceProvider.GetService<IMessageLogger>();
            //await messageLoggerService.WriteMessage("DI method");

            //var appInsightsLoggerService = _serviceProvider.GetService<IMessageLogger>();
            //await appInsightsLoggerService.WriteMessage("DI method");

            IEnumerable<IMessageLogger> services = _serviceProvider.GetServices<IMessageLogger>();
            var messageLoggerService = services.Where(s => s.Name == "MessageLogger").Single();
            await messageLoggerService.WriteMessage("Log in console");

            var appInsightsLoggerService = services.Where(s => s.Name == "AppInsightsLogger").Single();
            await appInsightsLoggerService.WriteMessage("Log in appinsights");

            DisposeServices();

            Console.ReadLine();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IMessageLogger, MessageLogger>(sp => new MessageLogger(""));
            collection.AddScoped<IMessageLogger, AppInsightsLogger>(sp => new AppInsightsLogger(""));
            // ...
            // Add other services
            // ...
            _serviceProvider = collection.BuildServiceProvider();
        }
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

    }
}
