using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Config
{
    public class PropuestaConfiguracion : IEntityTypeConfiguration<Propuesta>
    {
        public void Configure(EntityTypeBuilder<Propuesta> builder)
        {
            builder.HasKey(u =>
            new
            {
                u.Id,
            });
            builder.Property(t => t.Nombre)
                .IsRequired();
            builder.Property(t => t.RubroId)
    .IsRequired();
            builder.Property(t => t.Monto).HasColumnType("decimal(5,2)")
              .IsRequired();
            builder.Property(t => t.Descripcion)
   .IsRequired();
            builder.Property(t => t.ContratistaId)
   .IsRequired();
            builder.Property(t => t.UsuarioId)
.IsRequired();

            builder.HasOne(u => u.Contratista).WithMany(r => r.PropuestasContratistas).HasForeignKey(u => u.ContratistaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(u => u.Usuario).WithMany(r => r.PropuestasUsuarios).HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(u => u.Rubro).WithMany(r => r.Propuetas).HasForeignKey(u => u.RubroId);

        }
    }
}
