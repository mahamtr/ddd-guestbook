using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Events.Usuarios;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Responses;
using CleanArchitecture.Core.Services;
using CleanArchitecture.Interfaces;
using MediatR;

namespace CleanArchitecture.Core.Handlers.Usuarios
{
    public class LoginUserHandler : IRequestHandler<LoginUser, UserInfoResponse>
    {
        private readonly IAuthService _authService;
        private readonly IRepository _repository;

        public LoginUserHandler(IAuthService authService, IRepository repository)
        {
            _authService = authService;
            _repository = repository;
        }

        public async Task<UserInfoResponse> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            if (_authService.AuthenticateUser(request.Email, request.Password))
            {
                var user = _repository.List<Usuario>(t => t.Rol).First(u => u.Correo == request.Email);
                var tokenString =
                    _authService.GenerateJSONWebToken(user.Id, request.Key, request.Issuer, request.Audience);
                return new UserInfoResponse
                {
                    Token = tokenString,
                    Nombre = user.Nombre,
                    Apellido = user.Apellido,
                    Rol = user.Rol?.Nombre,
                };
            }

            throw new Exception("Correo o Password Incorrecto");
        }
    }
}

