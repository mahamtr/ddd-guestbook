using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class Rubro : BaseEntity
    {
        public virtual string Nombre { get; set; }
        public virtual ICollection<Propuesta> Propuetas{ get; set; }


    }
}
