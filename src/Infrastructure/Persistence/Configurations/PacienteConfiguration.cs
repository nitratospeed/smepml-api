using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder
                .ToTable("Paciente");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.NombresApellidos)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Edad)
                .IsRequired();

            builder
                .Property(x => x.Genero)
                .IsRequired()
                .HasMaxLength(1);
        }
    }
}
