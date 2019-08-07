using DependencyInjection.Interfaces;
using System;
using System.Threading.Tasks;

namespace DependencyInjection.Implementations
{
    public class EmailSender : INotification
    {
        public async Task ActOnNotification(string message)
        {
            // Write to event log here            
            await Console.Out.WriteLineAsync("EmailSender: Message sent - " + message);
        }
    }
}
