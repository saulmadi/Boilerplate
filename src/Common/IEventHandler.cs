using System.Threading.Tasks;

namespace Common
{
    public interface IEventHandler
    {
        
    }
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent: class, IEvent
    {

        Task Handle(TEvent @event);
    }
}