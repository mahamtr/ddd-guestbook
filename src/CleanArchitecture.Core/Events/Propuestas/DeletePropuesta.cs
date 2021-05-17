using CleanArchitecture.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Events.Propuestas
{
    public class DeletePropuesta : IRequest<Unit>
    {
        public Guid PropuestaId;

        public DeletePropuesta(Guid propuestaId)
        {
            PropuestaId = propuestaId;
        }
    }
}