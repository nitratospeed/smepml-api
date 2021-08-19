using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class IncidenciaConfiguration : IEntityTypeConfiguration<Incidencia>
    {
        public void Configure(EntityTypeBuilder<Incidencia> builder)
        {
            builder
                .ToTable("Incidencia");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Urgencia)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(x => x.AdjuntoUrl)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.Estado)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.CreadoEn)
                .IsRequired();

            builder
                .Property(x => x.CreadoPor)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.ActualizadoEn)
                .IsRequired(false);

            builder
                .Property(x => x.ActualizadoPor)
                .IsRequired(false)
                .HasMaxLength(250);
        }
    }
}
