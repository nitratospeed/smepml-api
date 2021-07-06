using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IAzureMLService
    {
        Task<GetPredictionResponse> GetPrediction(string Sexo, int Edad, List<string> Condiciones, List<string> Sintomas);
    }
}
