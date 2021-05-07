using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Web.Requests
{
    public class LoginRequest
    {
        [EmailAddress(ErrorMessage = "Enter valid Email address")]

        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Password cannot be longer than 40 characters and less than 8 characters")]

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
    }
}