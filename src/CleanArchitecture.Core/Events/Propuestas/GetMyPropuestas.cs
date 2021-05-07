using CleanArchitecture.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Events.Propuestas
{
    public class GetMyPropuestas : IRequest<IEnumerable<PropuestaDTO>>
    {
        public Guid UserId { get; set; }

        public GetMyPropuestas(Guid userId)
        {
            UserId = userId;
        }
    }
}