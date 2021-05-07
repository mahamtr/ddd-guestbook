using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Events.Propuestas;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Handlers.Propuestas
{
    public class AddPropuestaHandler : IRequestHandler<AddPropuesta, PropuestaDTO>
    {
        private readonly IRepository _repository;

        public AddPropuestaHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<PropuestaDTO> Handle(AddPropuesta request, CancellationToken cancellationToken)
        {
             var propuesta = _repository.Add<Propuesta>(new Propuesta {
                UsuarioId= request.userId,
                ContratistaId = request.contratistaId,
                Monto = request.monto,
                Nombre = request.nombre,
                Descripcion= request.descripcion,
                RubroId = request.rubroId
            });
            var prop = _repository.List<Propuesta>(t => t.Rubro, t => t.Contratista, t => t.Usuario).Find(p=> p.Id == propuesta.Id);
            return new PropuestaDTO {
            Nombre = prop.Nombre,
            Descripcion = prop.Descripcion,
            NombreContratista = $"{prop.Contratista.Nombre} + {prop.Contratista.Apellido}",
            NombreUsuario = $"{prop.Usuario.Nombre} + {prop.Usuario.Apellido}",
            Monto = prop.Monto,
            Rubro = prop.Rubro.Nombre,

            };

        }
    }
}
