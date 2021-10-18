using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class SeguimientoConfiguration : IEntityTypeConfiguration<Seguimiento>
    {
        public void Configure(EntityTypeBuilder<Seguimiento> builder)
        {
            builder
                .ToTable("Seguimiento");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .HasOne(x => x.Incidencia)
                .WithMany(x => x.Seguimientos)
                .HasForeignKey(x => x.IncidenciaId);
        }
    }
}
