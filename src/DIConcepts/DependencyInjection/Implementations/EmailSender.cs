using DependencyInjection.Interfaces;
using System;
using System.Threading.Tasks;

namespace DependencyInjection.Implementations
{
    public class EmailSender : INotification
    {
        public async Task ActOnNotification(string message)
        {
            // Write code to send email here            
            await Console.Out.WriteLineAsync("EmailSender: Message sent - " + message);
        }
    }
}
