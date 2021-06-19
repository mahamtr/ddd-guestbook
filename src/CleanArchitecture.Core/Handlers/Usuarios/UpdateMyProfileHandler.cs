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
    public class UpdateMyProfileHandler : IRequestHandler<UpdateMyProfile, UsuarioDTO>
    {
        private readonly IUserService _userService;
        private readonly IRepository _repository;
        
        
        public UpdateMyProfileHandler(IUserService userService, IRepository repository)
        {
            _userService = userService;
            _repository = repository;
        }
        public async Task<UsuarioDTO> Handle(UpdateMyProfile request, CancellationToken cancellationToken)
        {
            var user = _repository.List<Usuario>(t=> t.Rol).First(u=> u.Id== request.Id);
            user.Nombre = request.Nombre;
            user.Apellido = request.Apellido;
            user.Sexo = request.Sexo;
            user.Image_URL = request.ImagenURL;
            _repository.Update(user);
            user = _repository.List<Usuario>(t => t.Rol).First(u => u.Id == request.Id);
            return  new UsuarioDTO
            {
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Rol = user.Rol?.Nombre,
                Sexo = user.Sexo,
                Fecha = user.Fecha,
                Image_URL = user.Image_URL,
                Id = user.Id,
                Correo = user.Correo
            };
        }
    }
}