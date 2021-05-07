using CleanArchitecture.Core.Responses;
using MediatR;

namespace CleanArchitecture.Core.Events.Usuarios
{
    public class LoginUser : IRequest<UserInfoResponse>
    {
        public string Email { get;  }
        public string Password { get; }
        public string Key { get;  }
        public string Issuer { get; }
        public string Audience { get; }
        public LoginUser(string email, string password, string key, string issuer, string audience)
        {
            Email = email;
            Password = password;
            Key = key;
            Issuer = issuer;
            Audience = audience;
        }
    }
}