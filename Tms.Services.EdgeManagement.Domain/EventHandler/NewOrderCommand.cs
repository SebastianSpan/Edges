using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tms.Services.EdgeManagement.Domain.Services;

namespace Tms.Services.EdgeManagement.Domain.EventHandler
{
    // Sonstige:
    // BP.AUFTRAG, BP.VAR_AUFTRAG
    // BP.TOUR, BP.VAR_TOUR
    // BP.TOURENELEMENT
    // Änderungen CutOff Zeiten inkl. Gültigkeiten
    public class NewOrderCommand : EventHandlerBase<Order>
    {
        private readonly IDestinationLocator _destinationLocator;

        public NewOrderCommand(IDestinationLocator destinationLocator)
        {
            _destinationLocator = destinationLocator;
        }

        public async override Task ExecuteAsync(Order order)
        {
            Argument.ThrowIfNull(nameof(order), order);

            if(order.Positions == null || order.Positions.Count == 0)
            {
                throw new InvalidOperationException("Cannot process order without positions.");
            }

            var originNode = new Node
            { 
                Location = order.Location,
                EarliestArrival = order.Schedule.TimeWindowFrom,
                LastestArrival = order.Schedule.TimeWindowTo
            };

            order.Positions.GroupBy(e => e.Product.Id);
            var products = new List<ProductType>();
            foreach(var position in order.Positions)
            {
                if(products.Any(e=> e.Id == position.Product.Id))
                {
                    continue;
                }
            }
            // Step 1: locate destination(s) and generate blue edge(s) --> Generates 1 - n master edges
            // Step 2: Calculate distance and timewindows
            
            await Task.CompletedTask;
        }
    }

    public class DestinationFinder
    {
        public IEnumerable<DestinationNode> GetPossibleDestinations()
    }
}