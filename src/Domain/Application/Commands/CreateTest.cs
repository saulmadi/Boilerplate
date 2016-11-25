using Common;

namespace Domain.Application.Commands
{
    public class CreateTest : ICommand
    {
        
        public CreateTest(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}