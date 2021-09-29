﻿using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Diagnosticos.Queries
{
    public class GetDiagnosticosQuery : IRequest<PaginatedList<DiagnosticoDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string Nombres { get; set; } = "";
        public string Dni { get; set; } = "";
    }

    public class GetDiagnosticosQueryHandler : IRequestHandler<GetDiagnosticosQuery, PaginatedList<DiagnosticoDto>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetDiagnosticosQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PaginatedList<DiagnosticoDto>> Handle(GetDiagnosticosQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Diagnosticos.Include(x => x.Paciente)
                .Where(x=> (x.Paciente.Nombres.ToLower().Contains(request.Nombres.ToLower()) || request.Nombres == "") 
                    && (x.Paciente.Dni == request.Dni || request.Dni == ""))
                .OrderByDescending(x => x.Id)
                .ProjectTo<DiagnosticoDto>(mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
