using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tms.Services.EdgeManagement.Domain.Repository;

namespace Tms.Services.EdgeManagement.Domain.Commands
{
    // Sonstige:
    // BP.AUFTRAG, BP.VAR_AUFTRAG
    // BP.TOUR, BP.VAR_TOUR
    // BP.TOURENELEMENT
    // Änderungen CutOff Zeiten inkl. Gültigkeiten
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