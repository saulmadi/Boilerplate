using System.Threading.Tasks;

namespace Common
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task Execute(TCommand command);
    }
}