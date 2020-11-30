using System;
using System.Collections.Generic;

namespace Tms.Services.EdgeManagement.Domain
{
    public class Node
    {
        public Location Location { get; set; }

        public TimeSpan EarliestArrival { get; set; }

        public TimeSpan LastestArrival { get; set; }
    }
}