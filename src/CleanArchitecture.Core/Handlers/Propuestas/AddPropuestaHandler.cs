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
    public class AddPropuestaHandler : IRequestHandler<AddPropuesta, PropuestaDTO>
    {
        private readonly IRepository _repository;

        public AddPropuestaHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<PropuestaDTO> Handle(AddPropuesta request, CancellationToken cancellationToken)
        {
             var propuesta = _repository.Add(new Propuesta {
                UsuarioId= request.userId,
                ContratistaId = request.contratistaId,
                Monto = request.monto,
                Nombre = request.nombre,
                Descripcion= request.descripcion,
                RubroId = request.rubroId,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Status = Helpers.PropuestasStatus.EnRevision,
             });
            var imagenes = _repository.BulkInsert(request.Imagenes.Select(a => new Imagen {  URL = a.URL, PropuestaId = propuesta.Id }));
            var prop = _repository.List<Propuesta>(t => t.Rubro, t => t.Contratista, t => t.Usuario).Find(p=> p.Id == propuesta.Id);
            return new PropuestaDTO {
                Id = prop.Id,
                Nombre = prop.Nombre,
                Descripcion = prop.Descripcion,
                NombreContratista = $"{prop.Contratista.Nombre} {prop.Contratista.Apellido}",
                NombreUsuario = $"{prop.Usuario.Nombre} {prop.Usuario.Apellido}",
                Monto = prop.Monto,
                Rubro = prop.Rubro.Nombre,
                Updated = prop.Updated,
                Created = prop.Created,
                Status = PropuestasStatusExtensions.ToFriendlyString(prop.Status),
                Imagenes = imagenes.Select(a=> new ImagenDTO{ URL = a.URL}),
                               ContratistaId = prop.ContratistaId,
                RubroId = prop.RubroId,
                UsuarioId = prop.UsuarioId
            };

        }
    }
}
