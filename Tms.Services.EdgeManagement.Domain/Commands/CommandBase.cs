using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tms.Services.EdgeManagement.Domain.Commands
{
    public abstract class CommandBase<T> : ICommand<T>
    {
        public abstract Task ExecuteAsync(T obj);
    }
}