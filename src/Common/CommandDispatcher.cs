using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IEnumerable<ICommandHandler> _commandHandlers;

        public CommandDispatcher(IEnumerable<ICommandHandler> commandHandlers)
        {
            _commandHandlers = commandHandlers;
        }

        public async Task Dispatch<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var commandType = command.GetType();

            var commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);

            dynamic commandHandler =
                _commandHandlers.Cast<object>()
                    .FirstOrDefault(handler => commandHandlerType.IsInstanceOfType(handler));


            if (commandHandler != null)
                try
                {
                    Task commandExecution = commandHandler.Execute(command);
                    await commandExecution.ConfigureAwait(false);
                }

                catch (Exception ex)
                {
                    throw ex.GetBaseException();
                }
            else
                throw new Exception(string.Format("Can't find Command Handler for {0} ", commandType.Name));
        }
    }
}