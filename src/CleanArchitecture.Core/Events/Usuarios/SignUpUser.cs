using System;
using CleanArchitecture.Core.Responses;
using MediatR;

namespace CleanArchitecture.Core.Events.Usuarios
{
    public class SignUpUser : IRequest<UserInfoResponse>
    {


            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Password { get; set; }
            public string  Correo { get; set; }
            public Guid RolId { get; set; }
            public string Sexo{ get; set; }
            public string Image_URL { get; set; }
            public DateTime? Fecha{ get; set; }
        public SignUpUser(string nombre, string apellido, string password, string correo, Guid rolId, string sexo, string image_URL, DateTime? fecha)
        {
            Nombre = nombre;
            Apellido = apellido;
            Password = password;
            Correo = correo;
            RolId = rolId;
            Sexo = sexo;
            Image_URL = image_URL;
            Fecha = fecha;
        }



    }
}