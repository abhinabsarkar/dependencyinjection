using DependencyInjection.Interfaces;
using System.Threading.Tasks;

namespace DependencyInjection.Main
{
    public class AppPoolWatcher
    {
        // Handle to EventLog writer to write to the logs
        INotification notification = null;

        // Constructor dependency injection
        public AppPoolWatcher(INotification concreteImplementation)
        {
            this.notification = concreteImplementation;
        }

        // This function will be called when the app pool has problem
        public async Task Notify(string message)
        {
            await notification.ActOnNotification(message);
        }
    }
}
