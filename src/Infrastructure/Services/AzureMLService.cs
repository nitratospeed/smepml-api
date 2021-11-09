using Application.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AzureMLService : IAzureMLService
    {
        public class AzureMLRequest
        {
            public List<string> data { get; set; } = new List<string>();
        }

        public async Task<(string[], string)> GetPrediction(string sexo, int edad, string[] condiciones, string[] sintomas, string[] preguntas)
        {
            var handler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
            };
            using (var client = new HttpClient(handler))
            {
                var scoreRequest = new AzureMLRequest();

                scoreRequest.data.Add(string.Join(" ", sintomas));

                const string apiKey = "2zGHbBLYIA7GcR4qN7EBvzvFPRWdr6I5"; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("http://010ca3df-222d-448c-9f5f-06465d18e94f.centralus.azurecontainer.io/score");

                var requestString = JsonConvert.SerializeObject(scoreRequest);
                var content = new StringContent(requestString);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    var results = new List<string>();

                    var resultCleaned = result.Replace("{", "").Replace("}", "").Replace(@"\", "").Replace("\"", "").Replace(@"'", "");

                    foreach (var item in resultCleaned.Split(','))
                    {
                        var enf = item.Trim().Split(":")[0];
                        var porc = double.Parse(item.Trim().Split(":")[1]);
                        results.Add(enf + " : " + porc.ToString("P", CultureInfo.InvariantCulture));
                    }

                    var resultado = results;
                    var resultadoMasPreciso = results[0].Split(":")[0].Trim();

                    return (resultado.ToArray(), resultadoMasPreciso);
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
