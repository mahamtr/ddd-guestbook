using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Events.Rubros;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Handlers.Rubros
{
    public class GetAllRubrosHandler : IRequestHandler<GetAllRubros, IEnumerable<RubroDTO>>
    {
        private readonly IRepository _repository;

        public GetAllRubrosHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RubroDTO>> Handle(GetAllRubros request, CancellationToken cancellationToken)
        {
            return _repository.List<Rubro>().Select(r => new RubroDTO {Id = r.Id, Nombre = r.Nombre  });
        }
    }
}
