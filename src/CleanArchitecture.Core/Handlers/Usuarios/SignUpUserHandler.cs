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
    public class SignUpUserHandler : IRequestHandler<SignUpUser, UserInfoResponse>
    {
        private readonly IUserService _userService;
        private readonly IRepository _repository;
        
        
        public SignUpUserHandler(IUserService userService, IRepository repository)
        {
            _userService = userService;
            _repository = repository;
        }
        public async Task<UserInfoResponse> Handle(SignUpUser request, CancellationToken cancellationToken)
        {
            var token = _userService.SignUp(request.Nombre, request.Apellido, request.Password, request.Correo,
                request.RolId,request.Sexo,request.Image_URL,request.Fecha);
            var user = _repository.List<Usuario>(t=> t.Rol).First(u=> u.Correo == request.Correo);
            return  new UserInfoResponse
            {
                Token = token,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Rol = user.Rol?.Nombre,
                Sexo = user.Sexo,
                Fecha = user.Fecha,
                Image_URL = user.Image_URL
            };
        }
    }
}