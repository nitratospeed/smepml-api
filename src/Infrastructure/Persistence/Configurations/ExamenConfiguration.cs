using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ExamenConfiguration : IEntityTypeConfiguration<Examen>
    {
        public void Configure(EntityTypeBuilder<Examen> builder)
        {
            builder
                .ToTable("Examen");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .HasOne(x => x.Enfermedad)
                .WithMany(x => x.Examenes)
                .HasForeignKey(x => x.EnfermedadId);
        }
    }
}
