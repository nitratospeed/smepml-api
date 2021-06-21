using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class PreguntaConfiguration : IEntityTypeConfiguration<Pregunta>
    {
        public void Configure(EntityTypeBuilder<Pregunta> builder)
        {
            builder
                .ToTable("Pregunta");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .HasOne(x => x.Sintoma)
                .WithMany(x => x.Preguntas)
                .HasForeignKey(x=>x.SintomaId);
        }
    }
}
