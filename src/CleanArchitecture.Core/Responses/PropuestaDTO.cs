using System;

namespace CleanArchitecture.Core.Responses
{
    public class PropuestaDTO
    {
        public string Rubro { get; set; }
        public string NombreUsuario{ get; set; }
        public string NombreContratista { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto{ get; set; }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated{ get; set; }
        public string Status{ get; set; }
    }
}