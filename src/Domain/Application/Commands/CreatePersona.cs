using Common;

namespace Domain.Application.Commands
{
    public class CreatePersona : ICommand
    {
        public CreatePersona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}