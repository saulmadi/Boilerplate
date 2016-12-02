using System.Threading.Tasks;

namespace Common
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}