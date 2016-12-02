using System;
using Common;
using Domain.Application.Commands;
using Domain.Services;
using Nancy;
using Nancy.ModelBinding;

namespace Modules.Persona
{
    public class PersonaModule : NancyModule
    {
        public PersonaModule(ICommandDispatcher commandDispatcher, IRepository repository) : base("/personas")
        {
            Post["", true] = async (o, toke) =>
            {
                var request = this.Bind<PersonRequest>();

                await commandDispatcher.Dispatch(new CreatePersona(request.Nombre, request.Apellido));


                return null;
            };


            Get["", true] = async (o, token) =>
            {
                var personas = await repository.GetAll<Domain.Entities.Persona>();
                return personas;
            };

            Put["/{id:Guid}", true] = async (o, token) =>
            {
                var id = (Guid) o.id;
                var request = this.Bind<PersonRequest>();

                await commandDispatcher.Dispatch(new UpdatePersona(id,request.Nombre, request.Apellido));
                return null;
            };
        }
    }
}