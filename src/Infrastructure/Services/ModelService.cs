﻿using Application.Common.Interfaces.Services;
using Domain.Entities;
using Microsoft.ML;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ModelService : IModelService
    {
        private static PredictionEngine<ModelInput, ModelOutput> _predEngine;

        public async Task<List<string>> ObtenerPrediccion(string Sexo, int Edad, List<string> Condiciones, List<string> Sintomas)
        {
            string modelPath = "model.zip";

            MLContext _mlContext = new MLContext();

            ITransformer loadedModel = _mlContext.Model.Load(modelPath, out var modelInputSchema);

            string sintomas = string.Join(" ", Sintomas.ToArray());

            ModelInput singleIssue = new ModelInput() { SINTOMA = sintomas };

            _predEngine = _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(loadedModel);

            var prediction = _predEngine.Predict(singleIssue);

            var gg = new List<string>();
            gg.Add(prediction.ENFERMEDAD);
            return await Task.FromResult(gg);
        }

        public async Task<List<string>> ObtenerPrediccionAzure(string Sexo, int Edad, List<string> Condiciones, List<string> Sintomas)
        {
            string sintomas = string.Join(" ", Sintomas.ToArray());

            var handler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
            };
            using (var client = new HttpClient(handler))
            {
                // Request data goes here
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>()
                    {
                        {
                            "WebServiceInput0",
                            new List<Dictionary<string, string>>()
                            {
                                new Dictionary<string, string>()
                                {
                                    {
                                        "ENFERMEDAD", ""
                                    },
                                    {
                                        "SINTOMA", sintomas
                                    },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                

                const string apiKey = "2zGHbBLYIA7GcR4qN7EBvzvFPRWdr6I5"; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", apiKey);
                client.BaseAddress = new Uri("http://95079e12-7942-4f8c-8fde-43a58117e83e.centralus.azurecontainer.io/score");

                // WARNING: The 'await' statement below can result in a deadlock
                // if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false)
                // so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)

                var requestString = JsonConvert.SerializeObject(scoreRequest);
                var content = new StringContent(requestString);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    var resultConverted = JsonConvert.DeserializeObject<ModelAzure>(result);

                    var enfermedadMasProbable = resultConverted.Results.WebServiceOutput0[0].ScoredLabels;

                    var enfermedades = resultConverted.Results.WebServiceOutput0;

                    var top5enfermedades = new List<string>();

                    var columns = enfermedades.First().GetType().GetProperties();

                    IDictionary<string, string> enfermedadesScore = new Dictionary<string, string>();

                    foreach (var item in columns)
                    {
                        if (item.Name.Contains("ScoredProbabilities_"))
                        {
                            var ggg = item.GetValue(enfermedades.First()).ToString();
                            enfermedadesScore.Add(item.Name, ggg);
                        }
                    }

                    foreach (var item in enfermedadesScore.OrderByDescending(x => x.Value).Take(5))
                    {
                        var percDouble = double.Parse(item.Value);
                        var nombreEnf = item.Key.Replace("ScoredProbabilities_", "").Replace("_"," ");

                        top5enfermedades.Add(nombreEnf + " : " + percDouble.ToString("P", CultureInfo.InvariantCulture));
                    }

                    top5enfermedades.Add(enfermedades[0].ScoredLabels);

                    return top5enfermedades;
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp,
                    // which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                    return null;
                }
            }
        }
    }
}
