using System.Threading.Tasks;

namespace Tms.Services.EdgeManagement.Domain.Services
{
    public interface IDestinationLocator
    {  
        Task<DestinationNode> GetDestination(OrderPosition orderPosition);
    }
}