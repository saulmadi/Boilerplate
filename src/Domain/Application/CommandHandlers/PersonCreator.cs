using System;
using System.Threading.Tasks;
using Common;
using Domain.Application.Commands;
using Domain.Entities;
using Domain.Services;

namespace Domain.Application.CommandHandlers
{
    public class PersonCreator : CommandHandler<CreatePersona>
    {
        private readonly IRepository _repository;

        public PersonCreator(IRepository repository)
        {
            _repository = repository;
        }

        public override async Task Execute(CreatePersona command)
        {
            var persona = new Persona(Guid.NewGuid(), command.Nombre, command.Apellido);

            await _repository.Create(persona);
        }
    }
}