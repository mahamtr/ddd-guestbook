using System;

namespace CleanArchitecture.Core.Services
{
    public interface IAuthService
    {
        bool AuthenticateUser(string UserName, string Password);
        string GenerateJSONWebToken(Guid UserName, string key, string issuer, string audience);
        string GenerateHash(string password);

    }
}