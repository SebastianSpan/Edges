using System;
using System.Collections.Generic;

namespace Tms.Services.EdgeManagement.Domain
{
    public class OrderPosition
    {
        public OrderPosition(decimal quantity, ContainerType containerType, ProductType productType)
        {
            Container = containerType;
            Quantity = quantity;
        }

        public Order Order { get; set;}

        public ContainerType Container { get; set; }

        public decimal Quantity { get; set; }

        public ProductType Product { get; set; }
    }
}