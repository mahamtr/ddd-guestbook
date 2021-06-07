using System;

namespace CleanArchitecture.Core.Responses
{
    public class UserInfoResponse
    {
        public string Token { get; set; }
        public string Rol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Image_URL { get; set; }
        public DateTime Fecha{ get; set; }
    }
}