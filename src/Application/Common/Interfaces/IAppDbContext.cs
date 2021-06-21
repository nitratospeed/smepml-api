using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Enfermedad> Enfermedades { get; set; }
        DbSet<Paciente> Pacientes { get; set; }
        DbSet<Sintoma> Sintomas { get; set; }
        DbSet<Pregunta> Preguntas { get; set; }
        DbSet<Opcion> Opciones { get; set; }
    }
}
