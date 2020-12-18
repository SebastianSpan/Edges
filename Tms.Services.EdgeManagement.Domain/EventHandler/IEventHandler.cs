using System.Threading.Tasks;

namespace Tms.Services.EdgeManagement.Domain.EventHandler
{
    public interface IEventHandler<T>
    {        
        Task ExecuteAsync(T obj);
    }
}