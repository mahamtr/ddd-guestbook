using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Events.Propuestas;
using CleanArchitecture.Core.Helpers;
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
    public class UpdatePropuestaByIdHandler : IRequestHandler<UpdatePropuestaById, PropuestaDTO>
    {
        private readonly IRepository _repository;

        public UpdatePropuestaByIdHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<PropuestaDTO> Handle(UpdatePropuestaById request, CancellationToken cancellationToken)
        {
          
                var prop = _repository.GetById<Propuesta>(request.id);
                prop.ContratistaId = request.contratistaId;
                prop.Descripcion = request.descripcion;
                prop.RubroId = request.rubroId;
                prop.Nombre = request.nombre;
                prop.Descripcion = request.descripcion;
                prop.Monto = request.monto;
                prop.Updated= DateTime.UtcNow;
            prop.Status = (Helpers.PropuestasStatus)request.Status;

                _repository.Update(prop);
                prop = _repository.List<Propuesta>(t => t.Contratista, t => t.Usuario, t => t.Rubro).Find(a => a.Id == request.id);

                return new PropuestaDTO
                {
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
                };
      
        

        }
    }
}
