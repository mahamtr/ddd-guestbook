using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Web.Requests
{
    public class AddPropuestaRequest
    {
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

    }
}