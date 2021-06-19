using CleanArchitecture.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Events.Propuestas
{
    public class AddPropuesta : IRequest<PropuestaDTO>
    {
        public Guid userId;
        public Guid contratistaId;
        public Guid rubroId;
        public decimal monto;
        public string nombre;
        public string descripcion;
        public IEnumerable<ImagenDTO> Imagenes { get; set; }


        public AddPropuesta(Guid userId, Guid contratistaId, Guid rubroId, decimal monto, string nombre, string descripcion, IEnumerable<ImagenDTO> imagenes)
        {
            this.userId = userId;
            this.contratistaId = contratistaId;
            this.rubroId = rubroId;
            this.monto = monto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            Imagenes = imagenes;
        }
    }
}