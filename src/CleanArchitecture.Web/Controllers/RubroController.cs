using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CleanArchitecture.Core.Events.Usuarios;
using CleanArchitecture.Core.Helpers;
using CleanArchitecture.Core.Responses;
using CleanArchitecture.Core.Services;
using MediatR;
using CleanArchitecture.Core.Events.Rubros;

namespace CleanArchitecture.Web.Api
{
    public class RubroController : BaseApiController
    {
        private readonly IMediator _mediator;

        public RubroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IEnumerable<RubroDTO>> GetAllRubros()
        {
            return await _mediator.Send(new GetAllRubros());
        }


    }
}