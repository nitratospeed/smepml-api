using Application.Common.Interfaces.Services;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ModelService : IModelService
    {
        private static PredictionEngine<ModelInput, ModelOutput> _predEngine;

        public async Task<string> ObtenerPrediccion(string Sexo, int Edad, List<string> Condiciones, List<string> Sintomas)
        {
            string modelPath = "model.zip";

            MLContext _mlContext = new MLContext();

            ITransformer loadedModel = _mlContext.Model.Load(modelPath, out var modelInputSchema);

            string sintomas = string.Join(" ", Sintomas.ToArray());

            ModelInput singleIssue = new ModelInput() { SINTOMA = sintomas };

            _predEngine = _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(loadedModel);

            var prediction = _predEngine.Predict(singleIssue);
            Task completedTask = Task.CompletedTask;
            return prediction.ENFERMEDAD;
        }
    }
}
