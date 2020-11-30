using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tms.Services.EdgeManagement.Domain.Repository;
using Tms.Services.EdgeManagement.Domain.Services;

namespace Tms.Services.EdgeManagement.Domain.Commands
{
    public class NewOrderCommand : CommandBase<Order>
    {
        private readonly IDestinationRepository _destinationRepository;

        public NewOrderCommand(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async override Task ExecuteAsync(Order order)
        {
            Argument.ThrowIfNull(nameof(order), order);

            if(order.Positions == null || order.Positions.Count == 0)
            {
                throw new InvalidOperationException("Cannot process order without positions.");
            }

            // Step 1: locate destinations
            var destinations = await _destinationRepository.GetDestinations();
            var edges = new List<Edge>();
            foreach(var position in order.Positions)
            {
                foreach(var load in position.Loads)
                {
                    var possibleDestinations = destinations.Where(d => d.AcceptedProducts.Any(p => p.Id == load.Product.Id));
                }
            }

            await Task.CompletedTask;
        } 

        private static IEnumerable<(object, Schedule)> asdf(Schedule schedule, IEnumerable<(Schedule Schedule, object Item)> options)
        {
            foreach(var option in options)
            {
                if(schedule.ValidFrom >= option.Schedule.ValidFrom && (option.Schedule.ValidTo == null || schedule.ValidFrom <= option.Schedule.ValidTo))
                {
                    if(option.Schedule.ValidTo == null || option.Schedule.ValidTo.Value >= schedule.ValidTo)
                    {
                        return new (object, Schedule)[]
                        {
                            (option.Item, option.Schedule)
                        };
                    }                    
                }
            }
            return null;
        }
    }    
}