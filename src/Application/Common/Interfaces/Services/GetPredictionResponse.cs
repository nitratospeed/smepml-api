using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces.Services
{
    public class GetPredictionResponse
    {
        public List<string> Resultados { get; set; }
        public string EnfermedadMasPrecisa { get; set; }
    }
}
