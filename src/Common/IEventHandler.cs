using System.Threading.Tasks;

namespace Common
{
    public interface IEventHandler<in TEvent> where TEvent: class, IEvent
    {

        Task Handl(TEvent @event);
    }
}