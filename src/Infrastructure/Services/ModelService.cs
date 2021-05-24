using Application.Common.Interfaces.Services;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ModelService : IModelService
    {
        private static Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine);

        public async Task<string> ObtenerPrediccion(string Sintoma1, string Sintoma2, string Sintoma3)
        {
            var input = new ModelInput
            {
                SINTOMA1 = Sintoma1,
                SINTOMA2 = Sintoma2,
                SINTOMA3 = Sintoma3
            };

            ModelOutput result = PredictionEngine.Value.Predict(input);
            Task completedTask = Task.CompletedTask;
            return result.Prediction;
        }

        public static PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            //string modelPath = @"C:\Users\nitratospeed\AppData\Local\Temp\MLVSTools\SMEPMLBackML\SMEPMLBackML.Model\MLModel.zip";
            string modelPath = "MLModel.zip";
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            return predEngine;
        }
    }
}
