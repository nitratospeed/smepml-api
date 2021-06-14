using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IModelService
    {
        Task<List<string>> ObtenerPrediccion(string Sexo, int Edad, List<string> Condiciones, List<string> Sintomas);
        Task<List<string>> ObtenerPrediccionAzure(string Sexo, int Edad, List<string> Condiciones, List<string> Sintomas);
    }
}
