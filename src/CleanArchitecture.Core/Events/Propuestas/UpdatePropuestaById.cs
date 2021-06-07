using CleanArchitecture.Core.Helpers;
using CleanArchitecture.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Events.Propuestas
{
    public class UpdatePropuestaById : IRequest<PropuestaDTO>
    {
        public Guid id;
        public Guid contratistaId;
        public Guid rubroId;
        public decimal monto;
        public string nombre;
        public string descripcion;
        public int Status { get; set; }

        public UpdatePropuestaById(Guid Id, Guid contratistaId, Guid rubroId, decimal monto, string nombre, string descripcion, int status)
        {
            this.id = Id;
            this.contratistaId = contratistaId;
            this.rubroId = rubroId;
            this.monto = monto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            Status = status;
        }
    }
}