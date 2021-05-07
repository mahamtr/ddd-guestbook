using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CleanArchitecture.Core.Entities
{
    public class Usuario : BaseEntity
    {

        public virtual string Correo { get; set; }
        public virtual string CredencialHash { get; set; }
        public virtual string Nombre{ get; set; }
        public virtual string Apellido { get; set; }
        public virtual Guid RolId{ get; set; }
        public virtual Rol Rol { get; set; }
        public virtual ICollection<Propuesta> PropuestasUsuarios{ get; set; }
        public virtual ICollection<Propuesta> PropuestasContratistas { get; set; }




    }
}
