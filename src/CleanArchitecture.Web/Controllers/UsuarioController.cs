﻿using Microsoft.AspNetCore.Authorization;
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

namespace CleanArchitecture.Web.Api
{
    public class UsuarioController : BaseApiController
    {
        private IConfiguration _config;
        private IUserService _userService;
        private readonly IMediator _mediator;

        public UsuarioController(IConfiguration config, IAuthService authService, IUserService userService, IMediator mediator)
        {
            _config = config;
            _userService = userService;
            _mediator = mediator;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<UserInfoResponse> Login([FromBody] LoginRequest login)
        {
            return await _mediator.Send(new LoginUser(login.Email, login.Password, _config["Jwt:Key"],
                _config["JWT:Issuer"], _config["JWT:Audience"]));
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<UserInfoResponse> SignUpContratista([FromBody] SignUpRequest request)
        {
            return await _mediator.Send(new SignUpUser(request.Nombre, request.Apellido, request.Password,
                request.Email, Constants.RolIdContratista));
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<UserInfoResponse> SignUpUsuario([FromBody] SignUpRequest request)
        {
            return await _mediator.Send(new SignUpUser(request.Nombre, request.Apellido, request.Password,
                request.Email, Constants.RolIdUsuario));
        }

        [Authorize]
        [HttpPost]
        public async Task<IEnumerable<UsuarioDTO>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsers());
        }


        [Authorize]
        [HttpPost]
        public async Task<IEnumerable<UsuarioDTO>> GetAllContratistas()
        {
            return await _mediator.Send(new GetAllContratistas());
        }



    }
}