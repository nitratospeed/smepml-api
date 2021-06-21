using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class SintomaConfiguration : IEntityTypeConfiguration<Sintoma>
    {
        public void Configure(EntityTypeBuilder<Sintoma> builder)
        {
            builder
                .ToTable("Sintoma");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Nivel)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.HasNivel)
                .IsRequired();
        }
    }
}
