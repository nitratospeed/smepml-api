using SMEPMLBack.Core.Interfaces.Services;
using SMEPMLBackML.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMEPMLBack.Infrastructure.Services
{
    public class ModelService : IModelService
    {
        public async Task<string> ObtenerPrediccion(string Sintoma1, string Sintoma2, string Sintoma3)
        {
            var input = new ModelInput
            {
                SINTOMA1 = Sintoma1,
                SINTOMA2 = Sintoma2,
                SINTOMA3 = Sintoma3
            };

            ModelOutput result = ConsumeModel.Predict(input);
            Task completedTask = Task.CompletedTask;
            return result.Prediction;
        }
    }
}
