using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Events.Propuestas;
using CleanArchitecture.Core.Helpers;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Handlers.Propuestas
{
    public class GetMyPropuestasHanlder : IRequestHandler<GetMyPropuestas, IEnumerable<PropuestaDTO>>
    {
        private readonly IRepository _repository;

        public GetMyPropuestasHanlder(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PropuestaDTO>> Handle(GetMyPropuestas request, CancellationToken cancellationToken)
        {
            var user = _repository.GetById<Usuario>(request.UserId);
            var props = _repository.List<Propuesta>(t => t.Rubro, t => t.Contratista, t => t.Usuario);
             if (user.RolId == Constants.RolIdContratista)
            {
                props = props.Where(p => p.ContratistaId == request.UserId).ToList();

            }
            else
            {
                props = props.Where(p => p.UsuarioId == request.UserId).ToList();
            }

            return props.Select(prop => new PropuestaDTO
            {
                Id = prop.Id,
                Nombre = prop.Nombre,
                Descripcion = prop.Descripcion,
                NombreContratista = $"{prop.Contratista.Nombre} {prop.Contratista.Apellido}",
                NombreUsuario = $"{prop.Usuario.Nombre} {prop.Usuario.Apellido}",
                Monto = prop.Monto,
                Rubro = prop.Rubro.Nombre,
                Created= prop.Created,
                Updated = prop.Updated,
                                Status = PropuestasStatusExtensions.ToFriendlyString(prop.Status),

            });
        }
    }
}
