using System.Threading.Tasks;

namespace Tms.Services.EdgeManagement.Domain.Commands
{
    public interface ICommand<T>
    {        
        Task ExecuteAsync(T obj);
    }
}