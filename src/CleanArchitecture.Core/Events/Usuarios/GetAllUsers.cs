using System.Collections.Generic;
using CleanArchitecture.Core.Responses;
using MediatR;

namespace CleanArchitecture.Core.Events.Usuarios
{
    public class GetAllUsers : IRequest<IEnumerable<UsuarioDTO>>
    {
    }
}