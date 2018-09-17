using ReviewDB.Domain.Core.Commands;
using ReviewDB.Domain.Core.Events;
using System.Threading.Tasks;

namespace ReviewDB.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
