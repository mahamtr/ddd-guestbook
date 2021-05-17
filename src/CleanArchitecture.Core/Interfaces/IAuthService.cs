using System;

namespace CleanArchitecture.Interfaces
{
    public interface IAuthService
    {
        bool AuthenticateUser(string UserName, string Password);
        string GenerateJSONWebToken(Guid UserName, string key, string issuer, string audience);
        string GenerateHash(string password);

    }
}