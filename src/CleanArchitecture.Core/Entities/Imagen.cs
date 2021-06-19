using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Helpers;

namespace CleanArchitecture.Core.Entities
{
    public class Imagen : BaseEntity
    {
        public virtual Guid PropuestaId { get; set; }
        public virtual Propuesta Propuesta { get; set; }
        public virtual string URL { get; set; }


    }
}
