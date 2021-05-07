using CleanArchitecture.Core.Responses;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Events.Propuestas
{
    public class GetAllPropuestas : IRequest<IEnumerable<PropuestaDTO>>
    {
    }
}