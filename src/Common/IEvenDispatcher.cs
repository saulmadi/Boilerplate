using System.Threading.Tasks;

namespace Common
{
    public interface IEvenDispatcher
    {
        Task Raise<TEvent>(TEvent @event) where TEvent : class, IEvent;
    }
}