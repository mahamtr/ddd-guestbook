using CleanArchitecture.Core.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Web.Requests
{
    public class UpdateMyProfileRequest
    {
        [Required(ErrorMessage = "Required")]

        public string Nombre{ get; set; }

        [Required(ErrorMessage = "Required")]

        public string Apellido { get; set; }



        [Required(ErrorMessage = "Required")]

        public string ImagenURL { get; set; }

        [Required(ErrorMessage = "Required")]

        public string Sexo { get; set; }

    }
}