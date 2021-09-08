using Application.Core.Diagnosticos.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IAzureMLService
    {
        Task<(string[],string)> GetPrediction(string sexo, int edad, string[] condiciones, string[] sintomas, string[] preguntas);
    }
}
