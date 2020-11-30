using System;
using System.Collections.Generic;

namespace Tms.Services.EdgeManagement.Domain
{
    public class Location
    {
        public string Name { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string City { get; set; }
        
        public string PostCode { get; set; }

        public string Country { get; set; }

        public GeoPosition Position { get; set; }
    }
}