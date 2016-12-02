using System;
using Common;

namespace Domain.Application.Commands
{
    public class UpdatePersona : ICommand 
    {
        public Guid PersonId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public UpdatePersona(Guid personId, string nombre, string apellido)
        {
            PersonId = personId;
            Nombre = nombre;
            Apellido = apellido;
        }
    }
}