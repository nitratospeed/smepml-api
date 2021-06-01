using Application.Common.Interfaces.Services;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Predicciones.Queries
{
    public class GetPrediccionQuery : IRequest<string>
    {
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public List<string> Condiciones { get; set; }
        public List<string> Sintomas { get; set; }
    }

    public class GetPrediccionQueryHandler : IRequestHandler<GetPrediccionQuery, string>
    {
        private readonly IModelService service;

        public GetPrediccionQueryHandler(IModelService service)
        {
            this.service = service;
        }

        public async Task<string> Handle(GetPrediccionQuery request, CancellationToken cancellationToken)
        {
            var result = await service.ObtenerPrediccion(request.Sexo, request.Edad, request.Condiciones, request.Sintomas);

            return result;
        }
    }
}
