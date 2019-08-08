using DotnetCoreDI.Interfaces;
using System;
using System.Threading.Tasks;

namespace DotnetCoreDI.Services
{
    public class AppInsightsLogger : IMessageLogger
    {
        private readonly string _messageWriter;

        public string Name { get { return this.GetType().Name; } }

        // Constructor dependency injection
        public AppInsightsLogger(String messageWriter)
        {
            _messageWriter = messageWriter;
        }
        public Task WriteMessage(string message)
        {
            Console.WriteLine("Write Message called from AppInsightsLogger - " + message);
            return Task.FromResult(0);
        }
    }
}
