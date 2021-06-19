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
using CleanArchitecture.Web.Requests;
using MediatR;
using System.Security.Claims;
using System;
using CleanArchitecture.Core.Events.Propuestas;

namespace CleanArchitecture.Web.Api
{
    public class PropuestaController : BaseApiController
    {

        private readonly IMediator _mediator;

        public PropuestaController(IMediator mediator)
        {
            _mediator = mediator;
        }

    

        [Authorize]
        [HttpPost]
        public async Task<PropuestaDTO> AddPropuesta([FromBody] AddPropuestaRequest request)
        {
            var userId = new Guid((this.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return await _mediator.Send(new AddPropuesta(userId,request.ContratistaId, request.RubroId, request.Monto, request.Nombre,request.Descripcion,request.Imagenes));
        }

        [Authorize]
        [HttpPost]
        public async Task<IEnumerable<PropuestaDTO>> GetPropuestas()
        {
            return await _mediator.Send(new GetAllPropuestas());
        }

        [Authorize]
        [HttpPost]
        public async Task<IEnumerable<PropuestaDTO>> GetMyPropuestas()
        {
            var userId = new Guid((this.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return await _mediator.Send(new GetMyPropuestas(userId));
        }

        [HttpDelete]
        [Authorize]
        public async Task<Unit> DeletePropuestaById([FromBody] DeletePropuestaRequest request)
        {
            return await _mediator.Send(new DeletePropuesta(request.Id));
        }

        [HttpPost]
        [Authorize]
        public async Task<PropuestaDTO> UpdatePropuestaById([FromBody] UpdatePropuestaByIdRequest request)
        {
            return await _mediator.Send(new UpdatePropuestaById(request.Id,request.ContratistaId,request.RubroId,request.Monto,request.Nombre,request.Descripcion,request.Status,request.Imagenes));
        }

    }
}