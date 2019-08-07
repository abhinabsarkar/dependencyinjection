using System.Threading.Tasks;

namespace DependencyInjection.Interfaces
{
    public interface INotification
    {
        Task ActOnNotification(string message);
    }
}
