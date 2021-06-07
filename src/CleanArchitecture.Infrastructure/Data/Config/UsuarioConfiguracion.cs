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
            builder.Property(t => t.Fecha)
                .IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(t => t.Sexo).IsRequired().HasDefaultValue("Femenino");
            builder.Property(t => t.Image_URL).HasMaxLength(4096).IsRequired().HasDefaultValue("https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50?s=400");
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
