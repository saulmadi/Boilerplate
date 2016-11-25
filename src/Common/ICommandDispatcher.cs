using System.Threading.Tasks;

namespace Common
{
    public interface ICommandDispatcher
    {
        Task Disptach<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}