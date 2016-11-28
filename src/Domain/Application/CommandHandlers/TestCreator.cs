using System;
using System.Threading.Tasks;
using Common;
using Domain.Application.Commands;
using Domain.DomainEvents;
using Domain.Entities;

namespace Domain.Application.CommandHandlers
{
    public class TestCreator : CommandHandler<CreateTest>
    {
        public override async Task Execute(CreateTest command)
        {
            var test = new Test(Guid.NewGuid(), command.Name);

            await Raise(new TestCreated(test.Id));
        }
    }
}