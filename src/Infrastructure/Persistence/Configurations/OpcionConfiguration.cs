using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class OpcionConfiguration : IEntityTypeConfiguration<Opcion>
    {
        public void Configure(EntityTypeBuilder<Opcion> builder)
        {
            builder
                .ToTable("Opcion");

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
                .HasOne(x => x.Pregunta)
                .WithMany(x => x.Opciones)
                .HasForeignKey(x => x.PreguntaId);
        }
    }
}
