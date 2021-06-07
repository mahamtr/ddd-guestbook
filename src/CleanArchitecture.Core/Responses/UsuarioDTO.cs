using System;

namespace CleanArchitecture.Core.Responses
{
    public class UsuarioDTO
    {
        public Guid Id{ get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Image_URL{ get; set; }
        public DateTime Fecha{ get; set; }
        public string Apellido { get; set; }
    }
}