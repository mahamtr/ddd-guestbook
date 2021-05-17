using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository _repository;
        private byte[] salt = new byte[] { 62, 4, 14, 42, 12, 44, 62, 0 };

        public AuthService(IRepository repository)
        {
            _repository = repository;
        }


        public bool AuthenticateUser(string UserName, string Password)
        {
            var user = _repository.List<Usuario>().FirstOrDefault(i => i.Correo == UserName);
            if (user == null)
            {
                return false;
            }

            string hashed = GenerateHash(Password);
            return string.Equals(hashed, user.CredencialHash);
        }

        public string GenerateJSONWebToken(Guid userId, string key, string issuer, string audience)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            };

            var payload = new JwtPayload(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(60)
            );

            var token = new JwtSecurityToken(
                header,
                payload
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateHash(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                  password: password,
                  salt: this.salt,
                  prf: KeyDerivationPrf.HMACSHA1,
                  iterationCount: 10000,
                  numBytesRequested: 256 / 8));

        }
    }
}