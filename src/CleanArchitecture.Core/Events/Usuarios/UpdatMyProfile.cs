using System;
using CleanArchitecture.Core.Responses;
using MediatR;

namespace CleanArchitecture.Core.Events.Usuarios
{
    public class UpdateMyProfile : IRequest<UsuarioDTO>
    {



        public string Nombre { get; set; }
        public Guid Id{ get; set; }

        public UpdateMyProfile(string nombre, string apellido, string imagenURL, string sexo, Guid id)
        {
            Nombre = nombre;
            Apellido = apellido;
            ImagenURL = imagenURL;
            Sexo = sexo;
            Id = id;
        }

        public string Apellido { get; set; }




        public string ImagenURL { get; set; }


        public string Sexo { get; set; }



    }
}