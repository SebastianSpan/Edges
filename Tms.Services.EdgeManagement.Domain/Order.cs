using System;
using System.Collections.Generic;
using System.Linq;

namespace Tms.Services.EdgeManagement.Domain
{
    /// <summary>
    /// Repräsentiert einen Kundenauftrag.
    /// </summary>
    public class Order
    {
        public Order()
        {
            Positions = new List<OrderPosition>();            
        }

        public Location Location { get; set; }

        public Schedule Schedule { get; set; }

        public List<OrderPosition> Positions { get; private set; }
    }
}