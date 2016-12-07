using System.Threading.Tasks;
using Common;
using Domain.Application.Commands;
using Domain.Entities;
using Domain.Services;

namespace Domain.Application.CommandHandlers
{
    public class PersonUpdater : CommandHandler<UpdatePersona>
    {
        private readonly IRepository _repository;

        public PersonUpdater(IRepository repository)
        {
            _repository = repository;
        }
        public override async Task Execute(UpdatePersona command)
        {
            var persona = await _repository.GetById<Persona>(command.PersonId);
            persona.Nombre = command.Nombre;
            persona.Apellido = command.Apellido;

            await _repository.Update(persona);
        }
    }
}