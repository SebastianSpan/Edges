
using System.Collections.Generic;

namespace Tms.Services.EdgeManagement.Domain
{
    public class DestinationNode : Node
    {
        public List<ProductType> AcceptedProducts { get; set; }
        public Schedule Schedule { get; set; }
    }
}