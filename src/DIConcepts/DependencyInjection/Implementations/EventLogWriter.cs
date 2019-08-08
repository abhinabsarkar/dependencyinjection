using DependencyInjection.Interfaces;
using System;
using System.Threading.Tasks;

namespace DependencyInjection.Implementations
{
    public class EventLogWriter : INotification
    {
        public async Task ActOnNotification(string message)
        {
            // Write code to event log here            
            await Console.Out.WriteLineAsync("EventLogWriter: Message logged - " + message);
        }
    }
}
