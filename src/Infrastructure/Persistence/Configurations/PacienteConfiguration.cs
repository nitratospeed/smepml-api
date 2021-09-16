using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                .Property(x => x.Apellidos)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Nombres)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Dni)
                .IsRequired()
                .HasMaxLength(8);

            builder
                .Property(x => x.Celular)
                .IsRequired()
                .HasMaxLength(9);

            builder
                .Property(x => x.FechaNacimiento)
                .IsRequired();

            builder
                .Property(x => x.Correo)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(x => x.Direccion)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(x => x.Edad)
                .IsRequired();

            builder
                .Property(x => x.Genero)
                .IsRequired()
                .HasMaxLength(1);

            builder
                .Property(x => x.Estado)
                .IsRequired();
        }
    }
}
