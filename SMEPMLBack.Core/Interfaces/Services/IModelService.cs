using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMEPMLBack.Core.Interfaces.Services
{
    public interface IModelService
    {
        Task<string> ObtenerPrediccion(string Sintoma1, string Sintoma2, string Sintoma3);
    }
}
