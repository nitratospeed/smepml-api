using Application.Common.Interfaces.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Diagnosticos.Commands
{
    public class PredictDiagnosticoCommand : IRequest<PredictDiagnosticoDto>
    {
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string[] Condiciones { get; set; }
        public string[] Sintomas { get; set; }
        public string[] Preguntas { get; set; }
    }

    public class PredictDiagnosticoCommandHandler : IRequestHandler<PredictDiagnosticoCommand, PredictDiagnosticoDto>
    {
        private readonly IAzureMLService azureMLService;

        public PredictDiagnosticoCommandHandler(IAzureMLService azureMLService)
        {
            this.azureMLService = azureMLService;
        }

        public async Task<PredictDiagnosticoDto> Handle(PredictDiagnosticoCommand request, CancellationToken cancellationToken)
        {
            var result = await azureMLService.GetPrediction(request.Genero, request.Edad, request.Condiciones, request.Sintomas, request.Preguntas);

            var dto = new PredictDiagnosticoDto()
            {
                Resultados = result.Item1,
                ResultadoMasPreciso = result.Item2
            };

            return dto;
        }
    }
}
