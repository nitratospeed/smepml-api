using Microsoft.EntityFrameworkCore;
using SMEPMLBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMEPMLBack.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Enfermedad> Enfermedad { get; set; }
        public DbSet<Sintoma> Sintoma { get; set; }
        public DbSet<Paciente> Paciente { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
                    : base(options)
        {
        }
    }
}
