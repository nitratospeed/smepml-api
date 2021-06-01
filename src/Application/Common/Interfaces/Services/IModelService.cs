using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IModelService
    {
        Task<string> ObtenerPrediccion(string Sexo, int Edad, List<string> Condiciones, List<string> Sintomas);
    }
}
