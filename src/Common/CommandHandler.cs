using System.Threading.Tasks;

namespace Common
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        public IEvenDispatcher EvenDispatcher { get; set; }

        public abstract Task Execute(TCommand command);

        protected async Task Raise<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            await EvenDispatcher.Raise(@event);
        }
    }
}