using DependencyInjection.Implementations;
using DependencyInjection.Main;
using System;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        // Dependency Injection example
        static async Task Main(string[] args)
        {
            // Create an object of the concrete class
            EventLogWriter writer = new EventLogWriter();
            
            // Constructor Injection 
            // Pass the object of the concrete class into the constructor of the dependent class.
            AppPoolWatcher watcher = new AppPoolWatcher(writer);
            await watcher.Notify("Sample message to log");

            // By virtue of using Dependency Injection, a new requirement can be extended by adding a new implementation.
            // In this case, adding implementation class EmailSender which is extended from the abstract class (Interface) INotificationAction.
            EmailSender emailSender = new EmailSender();
            watcher = new AppPoolWatcher(emailSender);
            await watcher.Notify("Sample message to email");

            Console.WriteLine("Hello Dependency Injection via Constructor!");
            Console.ReadLine();
        }
    }
}
