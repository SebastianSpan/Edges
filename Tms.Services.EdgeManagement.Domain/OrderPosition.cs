using System;
using System.Collections.Generic;

namespace Tms.Services.EdgeManagement.Domain
{
    public class OrderPosition
    {
        public OrderPosition(int quantity, ContainerType containerType,  Load[] loads)
        {
            Container = containerType;
            Quantity = quantity;
            Loads = new List<Load>(loads);
        }

        public OrderPosition(int quantity, ContainerType containerType, ProductType productType)
            : this(quantity, containerType, new Load[] { new Load( productType, 1 )})
        {
        }


        public ContainerType Container { get; set; }

        public int Quantity { get; set; }

        public List<Load> Loads { get; set; }
    }

    public class Load
    {
        public Load(ProductType productType, double amount)
        {
            Product = productType;
            Amount = amount;
        }

        public Load(ProductType productType)
            : this(productType, 1)
        {            
        }

        public ProductType Product { get; private set; }

        public double Amount { get; private set; }
    }
}