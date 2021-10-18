using Application.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AzureMLService : IAzureMLService
    {
        public async Task<(string[], string)> GetPrediction(string sexo, int edad, string[] condiciones, string[] sintomas, string[] preguntas)
        {
            string sintomasJoined = string.Join(" ", sintomas);

            var handler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
            };
            using (var client = new HttpClient(handler))
            {
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
                                        "SINTOMA", sintomasJoined
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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("http://95079e12-7942-4f8c-8fde-43a58117e83e.centralus.azurecontainer.io/score");

                var requestString = JsonConvert.SerializeObject(scoreRequest);
                var content = new StringContent(requestString);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    var resultConverted = JsonConvert.DeserializeObject<AzureMLResponse>(result);

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
                        var nombreEnf = item.Key.Replace("ScoredProbabilities_", "").Replace("_", " ");

                        top5enfermedades.Add(nombreEnf + " : " + percDouble.ToString("P", CultureInfo.InvariantCulture));
                    }

                    var resultado = top5enfermedades.ToArray();
                    var resultadoMasPreciso = enfermedades[0].ScoredLabels;

                    return (resultado, resultadoMasPreciso);
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));
                    Console.WriteLine(response.Headers.ToString());
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                    return (null, "");
                }
            }
        }
    }
}
