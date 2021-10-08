﻿using Application.Common.Interfaces;
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

                foreach (var sintoma in sintomas.GroupBy(x=>x))
                {
                    listDto.Add(new ReportDiagnosticosDto { Name = sintoma.Key, Value = sintoma.Count().ToString() });
                }
            }

            return listDto;
        }
    }
}
