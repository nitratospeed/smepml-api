using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAzureMLService
    {
        Task<(string[], string)> GetPrediction(string sexo, int edad, string[] condiciones, string[] sintomas, string[] preguntas);
    }
}
