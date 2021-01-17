using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMEPMLBack.Infrastructure.Repositories
{
    public class SintomaRepository : ISintomaRepository
    {
        public List<Sintoma> ObtenerSintomas()
        {
            var sintomas = new List<Sintoma>();

            sintomas.Add(new Sintoma { Id = 1, Nombre = "Dolor de estómago" });
            sintomas.Add(new Sintoma { Id = 2, Nombre = "Dolor de cabeza" });
            sintomas.Add(new Sintoma { Id = 3, Nombre = "Fiebre" });
            sintomas.Add(new Sintoma { Id = 4, Nombre = "Vómitos" });
            sintomas.Add(new Sintoma { Id = 5, Nombre = "Diarrea" });

            return sintomas;
        }
    }
}
