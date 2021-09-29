using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Diagnosticos.Queries
{
    public class ReportDiagnosticosQuery : IRequest<List<ReportDiagnosticosDto>>
    {
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

            foreach (var item in result.GroupBy(x=>x.ResultadoMasPreciso))
            {
                listDto.Add(new ReportDiagnosticosDto { Name = item.Key, Value = item.Count().ToString() });
            }

            return listDto;
        }
    }
}
