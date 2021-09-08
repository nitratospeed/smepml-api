using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class DiagnosticoConfiguration : IEntityTypeConfiguration<Diagnostico>
    {
        public void Configure(EntityTypeBuilder<Diagnostico> builder)
        {
            builder
                .ToTable("Diagnostico");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Condiciones)
                .IsRequired();

            builder
                .Property(x => x.Sintomas)
                .IsRequired();

            builder
                .Property(x => x.Preguntas)
                .IsRequired();

            builder
                .Property(x => x.Resultados)
                .IsRequired();

            builder
                .Property(x => x.ResultadoMasPreciso)
                .IsRequired();

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

            builder
                .HasOne(x => x.Paciente)
                .WithMany(x => x.Diagnosticos)
                .HasForeignKey(x => x.PacienteId);
        }
    }
}
