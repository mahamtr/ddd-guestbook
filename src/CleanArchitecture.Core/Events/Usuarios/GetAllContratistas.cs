using System.Collections.Generic;
using CleanArchitecture.Core.Responses;
using MediatR;

namespace CleanArchitecture.Core.Events.Usuarios
{
    public class GetAllContratistas : IRequest<IEnumerable<UsuarioDTO>>
    {
    }
}