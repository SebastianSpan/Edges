using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tms.Services.EdgeManagement.Domain.Repository
{
    public interface IDestinationRepository
    {  
        Task<IEnumerable<DestinationNode>> GetDestinations();
    }
}