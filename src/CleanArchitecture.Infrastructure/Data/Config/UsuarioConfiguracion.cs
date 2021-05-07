using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u =>
            new
            {
                u.Id,
            });
            builder.Property(t => t.Nombre)
                .IsRequired();
            builder.Property(t => t.Apellido)
              .IsRequired();
            builder.Property(t => t.CredencialHash)
   .IsRequired();
            builder.Property(t => t.Correo)
   .IsRequired();
            builder.Property(t => t.RolId)
.IsRequired();
            
            builder.HasOne(u=> u.Rol).WithMany(r=> r.Usuarios).HasForeignKey(u=> u.RolId);

        }
    }
}
