using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Web.Requests
{
    public class SignUpRequest
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Enter valid Email address")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "Required")]

        public string Apellido { get; set; }
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Password cannot be longer than 40 characters and less than 8 characters")]

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
    }
}