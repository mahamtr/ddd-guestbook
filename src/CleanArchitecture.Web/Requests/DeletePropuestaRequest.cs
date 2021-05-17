using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Web.Requests
{
    public class DeletePropuestaRequest
    {
        [Required(ErrorMessage = "Required")]

        public Guid Id{ get; set; }

    }
}