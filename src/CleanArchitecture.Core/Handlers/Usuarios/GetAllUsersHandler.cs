using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Events.Usuarios;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Responses;
using MediatR;

namespace CleanArchitecture.Core.Handlers.Usuarios
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<UsuarioDTO>>
    {
        private readonly IRepository _repository;


        public GetAllUsersHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioDTO>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {

            return _repository.List<Usuario>(t=> t.Rol).Select(u=> new UsuarioDTO
            {
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                Rol = u.Rol?.Nombre
            });
        }
    }
}