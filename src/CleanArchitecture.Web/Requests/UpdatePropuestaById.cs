using CleanArchitecture.Core.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Web.Requests
{
    public class UpdatePropuestaByIdRequest
    {
        [Required(ErrorMessage = "Required")]

        public Guid Id { get; set; }
        [Required(ErrorMessage = "Required")]

        public Guid ContratistaId{ get; set; }
        [Required(ErrorMessage = "Required")]

        public Guid RubroId { get; set; }

        [Required(ErrorMessage = "Required")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "Required")]

        public string Descripcion{ get; set; }

        [Required(ErrorMessage = "Required")]

        public decimal Monto{ get; set; }
        [Required(ErrorMessage = "Required")]

        public int Status{ get; set; }

        [Required(ErrorMessage = "Required")]

        public IEnumerable<ImagenDTO> Imagenes { get; set; }



    }
}