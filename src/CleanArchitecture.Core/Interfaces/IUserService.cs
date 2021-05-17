using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Interfaces
{
    public interface IUserService
    {
        string SignUp(string nombre, string apellido, string password, string correo, Guid rolId);
    }
}