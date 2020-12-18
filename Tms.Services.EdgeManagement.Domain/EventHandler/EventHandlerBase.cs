using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tms.Services.EdgeManagement.Domain.EventHandler
{
    public abstract class EventHandlerBase<T> : IEventHandler<T>
    {
        public abstract Task ExecuteAsync(T obj);
    }
}