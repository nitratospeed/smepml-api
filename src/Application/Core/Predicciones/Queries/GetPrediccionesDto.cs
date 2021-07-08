using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Predicciones.Queries
{
    public class GetPrediccionesDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Sintomas { get; set; }
        public string ResultadoMasPreciso { get; set; }
    }
}
