using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Diagnosticos.Queries
{
    public class ReportDiagnosticosQuery : IRequest<List<ReportDiagnosticosDto>>
    {
        public int TipoReporte { get; set; }
    }

    public class ReportDiagnosticosQueryHandler : IRequestHandler<ReportDiagnosticosQuery, List<ReportDiagnosticosDto>>
    {
        private readonly IAppDbContext context;

        public ReportDiagnosticosQueryHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ReportDiagnosticosDto>> Handle(ReportDiagnosticosQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Diagnosticos.ToListAsync();

            var listDto = new List<ReportDiagnosticosDto>();

            if (request.TipoReporte == 1)
            {
                foreach (var item in result.GroupBy(x => x.ResultadoMasPreciso))
                {
                    listDto.Add(new ReportDiagnosticosDto { Name = item.Key, Value = item.Count().ToString() });
                }
            }

            var sintomas = new List<string>();

            if (request.TipoReporte == 2)
            {
                foreach (var item in result.Select(x => x.Sintomas.Split(",").ToList()))
                {
                    sintomas.AddRange(item);
                }

                foreach (var sintoma in sintomas.GroupBy(x => x))
                {
                    listDto.Add(new ReportDiagnosticosDto { Name = sintoma.Key, Value = sintoma.Count().ToString() });
                }
            }

            if (request.TipoReporte == 3)
            {
                foreach (var item in result.GroupBy(x => x.CreadoPor))
                {
                    var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Correo == item.Key);
                    listDto.Add(new ReportDiagnosticosDto { Name = usuario.NombreCompleto, Value = item.Count().ToString() });
                }
            }

            if (request.TipoReporte == 4)
            {
                foreach (var item in result.GroupBy(x => x.Calificacion.ToString()))
                {
                    listDto.Add(new ReportDiagnosticosDto { Name = item.Key, Value = item.Count().ToString() });
                }
            }

            return listDto;
        }
    }
}
