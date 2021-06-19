using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Helpers;

namespace CleanArchitecture.Core.Entities
{
    public class Propuesta : BaseEntity
    {
        public virtual Guid RubroId { get; set; }
        public virtual Rubro Rubro { get; set; }
        public virtual Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Guid ContratistaId { get; set; }
        public virtual Usuario Contratista { get; set; }
        public virtual string Nombre{ get; set; }
        public virtual string Descripcion { get; set; }
        public virtual decimal Monto{ get; set; }
        public virtual DateTime Created{ get; set; }
        public virtual DateTime Updated{ get; set; }
        public virtual PropuestasStatus Status{ get; set; }
        public virtual ICollection<Imagen> Imagenes{ get; set; }


    }
}
