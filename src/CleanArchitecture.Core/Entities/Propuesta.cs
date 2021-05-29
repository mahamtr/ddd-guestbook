﻿using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

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


    }
}