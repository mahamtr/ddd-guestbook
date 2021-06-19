using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Config
{
    public class RubroConfiguracion : IEntityTypeConfiguration<Rubro>
    {
        public void Configure(EntityTypeBuilder<Rubro> builder)
        {
            builder.HasKey(u =>
            new
            {
                u.Id,
            });
            builder.Property(t => t.Nombre)
                .IsRequired();


        }
    }
}
