﻿using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Config
{
    public class ImagenConfiguracion : IEntityTypeConfiguration<Imagen>
    {
        public void Configure(EntityTypeBuilder<Imagen> builder)
        {
            builder.HasKey(u =>
            new
            {
                u.Id,
            });
            builder.Property(t => t.URL)
                .IsRequired();
            builder.Property(t => t.PropuestaId)
        .IsRequired();

            builder.HasOne(u => u.Propuesta).WithMany(r => r.Imagenes).HasForeignKey(u => u.PropuestaId);

        }
    }
}
