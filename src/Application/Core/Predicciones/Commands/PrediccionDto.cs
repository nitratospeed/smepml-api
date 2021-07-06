using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Predicciones.Commands
{
    public class PrediccionDto
    {
        public List<string> Enfermedades { get; set; }
        public string Recomendacion { get; set; }
    }
}
