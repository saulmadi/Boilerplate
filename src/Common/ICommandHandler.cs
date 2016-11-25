using System.Threading.Tasks;

namespace Common
{
    public interface ICommandHandler
    {
        
    }
    public interface ICommandHandler<in TCommand> : ICommandHandler  where TCommand : class, ICommand 
    {
        Task Execute(TCommand command);
    }
}