using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .ToTable("Usuario");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Correo)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.Contrasena)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.NombreCompleto)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.Perfil)
                .IsRequired()
                .HasConversion(x => x.ToString(), x => (PerfilEnum)Enum.Parse(typeof(PerfilEnum), x));

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
