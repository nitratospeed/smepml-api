using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDateTime dateTime;

        public AppDbContext(DbContextOptions options, ICurrentUserService currentUserService, IDateTime dateTime) : base(options)
        {
            this.currentUserService = currentUserService;
            this.dateTime = dateTime;
        }

        public DbSet<Enfermedad> Enfermedades { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Sintoma> Sintomas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Opcion> Opciones { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<Configuracion> Configuraciones { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreadoPor = currentUserService.UserName;
                        entry.Entity.CreadoEn = dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ActualizadoPor = currentUserService.UserName;
                        entry.Entity.ActualizadoEn = dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
