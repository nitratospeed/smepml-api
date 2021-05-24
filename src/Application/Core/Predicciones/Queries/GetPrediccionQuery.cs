using Application.Common.Interfaces.Services;
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
        public string Sintoma1 { get; set; }
        public string Sintoma2 { get; set; }
        public string Sintoma3 { get; set; }
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
            var result = await service.ObtenerPrediccion(request.Sintoma1, request.Sintoma2, request.Sintoma3);

            return result;
        }
    }
}
