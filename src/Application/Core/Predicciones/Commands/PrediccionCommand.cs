using Application.Common.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Predicciones.Commands
{
    public class PrediccionCommand : IRequest<List<string>>
    {
        public string NombresApellidos { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public List<string> Condiciones { get; set; }
        public List<string> Preguntas { get; set; }
        public List<string> Sintomas { get; set; }
    }

    public class PrediccionCommandHandler : IRequestHandler<PrediccionCommand, List<string>>
    {
        private readonly IModelService service;

        public PrediccionCommandHandler(IModelService service)
        {
            this.service = service;
        }

        public async Task<List<string>> Handle(PrediccionCommand request, CancellationToken cancellationToken)
        {
            var result = await service.ObtenerPrediccionAzure(request.Genero, request.Edad, request.Condiciones, request.Sintomas);

            return result;
        }
    }
}
