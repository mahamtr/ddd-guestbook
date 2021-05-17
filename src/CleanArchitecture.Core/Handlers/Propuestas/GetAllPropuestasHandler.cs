using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Events.Propuestas;
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
    public class GetAllPropuestasHandler : IRequestHandler<GetAllPropuestas, IEnumerable<PropuestaDTO>>
    {
        private readonly IRepository _repository;

        public GetAllPropuestasHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PropuestaDTO>> Handle(GetAllPropuestas request, CancellationToken cancellationToken)
        {
            var props = _repository.List<Propuesta>(t => t.Rubro, t => t.Contratista, t => t.Usuario);
            return props.Select(prop => new PropuestaDTO
            {
                Id = prop.Id,
                Nombre = prop.Nombre,
                Descripcion = prop.Descripcion,
                NombreContratista = $"{prop.Contratista.Nombre} + {prop.Contratista.Apellido}",
                NombreUsuario = $"{prop.Usuario.Nombre} + {prop.Usuario.Apellido}",
                Monto = prop.Monto,
                Rubro = prop.Rubro.Nombre,

            });
        }
    }
}
