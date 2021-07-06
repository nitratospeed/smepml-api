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
                .Property(x => x.Preguntas)
                .IsRequired();

            builder
                .Property(x => x.Sintomas)
                .IsRequired();

            builder
                .HasOne(x => x.Paciente)
                .WithMany(x => x.Diagnosticos)
                .HasForeignKey(x => x.PacienteId);
        }
    }
}
