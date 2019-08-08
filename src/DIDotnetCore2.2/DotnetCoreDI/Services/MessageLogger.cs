using DotnetCoreDI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreDI.Services
{
    public class MessageLogger : IMessageLogger
    {
        private readonly string _messageWriter;

        public string Name { get { return this.GetType().Name; } }

        // Constructor dependency injection
        public MessageLogger(String messageWriter)
        {
            _messageWriter = messageWriter;
        }        

        public Task WriteMessage(string message)
        {
            Console.WriteLine("Write Message called from message logger - " + message);
            return Task.FromResult(0);
        }

    }
}
