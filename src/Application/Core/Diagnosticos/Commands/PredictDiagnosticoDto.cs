using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Diagnosticos.Commands
{
    public class PredictDiagnosticoDto
    {
        public string[] Resultados { get; set; }
        public string ResultadoMasPreciso { get; set; }
    }
}
