using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public class EvenDispatcher : IEvenDispatcher
    {
        private readonly IEnumerable<IEventHandler> _eventHandlers;

        public EvenDispatcher(IEnumerable<IEventHandler> eventHandlers)
        {
            _eventHandlers = eventHandlers;
        }

        public async Task Raise<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            var commandType = @event.GetType();

            var eventHandlerType = typeof(IEventHandler<>).MakeGenericType(commandType);

            var eventHandlers =
                _eventHandlers.Cast<object>()
                    .Where(handler => eventHandlerType.IsInstanceOfType(handler))
                    .Distinct(new TypeEqualityComparer());


            foreach (dynamic handler in eventHandlers)
            {
                Task eventExecution = handler.Handle(@event);
                try
                {
                    await eventExecution.ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex.GetBaseException();
                }
            }
        }
    }
}