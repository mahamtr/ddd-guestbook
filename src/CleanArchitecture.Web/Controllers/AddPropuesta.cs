using CleanArchitecture.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Events.Propuestas
{
    internal class AddPropuesta : IRequest<PropuestaDTO>
    {
        private Guid userId;
        private Guid contratistaId;
        private Guid rubroId;
        private decimal monto;
        private string nombre;
        private string descripcion;

        public AddPropuesta(Guid userId, Guid contratistaId, Guid rubroId, decimal monto, string nombre, string descripcion)
        {
            this.userId = userId;
            this.contratistaId = contratistaId;
            this.rubroId = rubroId;
            this.monto = monto;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}