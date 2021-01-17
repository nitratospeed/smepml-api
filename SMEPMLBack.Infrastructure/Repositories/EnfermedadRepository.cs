using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMEPMLBack.Infrastructure.Repositories
{
    public class EnfermedadRepository : IEnfermedadRepository
    {
        public List<Enfermedad> ObtenerEnfermedades()
        {
            var enfermedades = new List<Enfermedad>();

            enfermedades.Add(new Enfermedad { Id = 1, Nombre = "Infección Estomacal" });
            enfermedades.Add(new Enfermedad { Id = 2, Nombre = "Gastritis" });
            enfermedades.Add(new Enfermedad { Id = 3, Nombre = "Intolerancia Lactosa" });
            enfermedades.Add(new Enfermedad { Id = 4, Nombre = "Gastroenteritis" });
            enfermedades.Add(new Enfermedad { Id = 5, Nombre = "Vesícula Inflamada" });

            return enfermedades;
        }
    }
}
