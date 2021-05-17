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
    public class DeletePropuestaHandler : IRequestHandler<DeletePropuesta, Unit>
    {
        private readonly IRepository _repository;

        public DeletePropuestaHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePropuesta request, CancellationToken cancellationToken)
        {
            var propuestaToDelete = _repository.GetById<Propuesta>(request.PropuestaId);
             _repository.Delete(propuestaToDelete);
            return Unit.Value;
        }
    }
}
