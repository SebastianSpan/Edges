using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tms.Services.EdgeManagement.Domain.Services
{
    public class DestinationLocator : IDestinationLocator
    {
        private readonly IEnumerable<DestinationNode> _destinationNodes;

        public DestinationLocator(IEnumerable<DestinationNode> destinationNodes)
        {
            Argument.ThrowIfNull(nameof(destinationNodes), destinationNodes);

            _destinationNodes = destinationNodes;
        }

        public async Task<DestinationNode> GetDestination(OrderPosition orderPosition)
        {
            Argument.ThrowIfNull(nameof(orderPosition), orderPosition);
            Argument.ThrowIfNull(nameof(orderPosition.Order), orderPosition.Order);

            // TODO: This is wrong
            return _destinationNodes.FirstOrDefault(n => 
                n.Location.PostCode == orderPosition.Order.Location.PostCode &&
                n.AcceptedProducts.Any(p => p.Id == orderPosition.Product.Id));
        }
    }
}