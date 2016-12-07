using System;

namespace Domain.Entities
{
    public class Persona : Entity
    {
        protected Persona()
        {
            
        }
        public Persona(Guid id, string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
            Id = id;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}