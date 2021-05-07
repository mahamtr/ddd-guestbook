using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class Rol : BaseEntity
    {
        public virtual string Nombre { get; set; }
        public virtual ICollection<Usuario> Usuarios{ get; set; }
    }
}
