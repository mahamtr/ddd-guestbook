using System;
using System.Collections;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Responses
{
    public class PropuestaDTO
    {
        public string Rubro { get; set; }
        public Guid RubroId { get; set; }
        public string NombreUsuario{ get; set; }
        public string NombreContratista { get; set; }
        public Guid ContratistaId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto{ get; set; }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated{ get; set; }
        public string Status{ get; set; }
        public IEnumerable<ImagenDTO> Imagenes{ get; set; }
    }
}