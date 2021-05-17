using System;
using System.Linq;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly IAuthService _authService;
        private IConfiguration _config;


        public UserService(IRepository repository, IAuthService authService, IConfiguration config)
        {
            _repository = repository;
            _authService = authService;
            _config = config;
        }

        public string SignUp(string nombre, string apellido, string password, string correo, Guid rolId)
        {
            var user = _repository.List<Usuario>(   ).FirstOrDefault(a => a.Correo == correo);
            if(user != null) throw  new Exception("Correo ya existe");
            var passwdHash = _authService.GenerateHash(password);
            _repository.Add(new Usuario
                {Nombre = nombre, Apellido = apellido, Correo = correo, CredencialHash = passwdHash, RolId = rolId});
             user = _repository.List<Usuario>().FirstOrDefault(a => a.Correo == correo);
            return _authService.GenerateJSONWebToken(user.Id,_config["Jwt:Key"],_config["JWT:Issuer"],_config["JWT:Audience"]);
        }
    }
}