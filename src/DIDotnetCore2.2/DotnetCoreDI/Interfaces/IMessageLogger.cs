using System.Threading.Tasks;

namespace DotnetCoreDI.Interfaces
{
    public interface IMessageLogger
    {
        string Name { get; }

        Task WriteMessage(string message);
    }
}