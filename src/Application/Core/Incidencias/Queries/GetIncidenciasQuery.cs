﻿using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Incidencias.Queries
{
    public class GetIncidenciasQuery : IRequest<PaginatedList<IncidenciaDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class GetIncidenciasQueryHandler : IRequestHandler<GetIncidenciasQuery, PaginatedList<IncidenciaDto>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetIncidenciasQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PaginatedList<IncidenciaDto>> Handle(GetIncidenciasQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Incidencias
                .OrderByDescending(x => x.Id)
                .ProjectTo<IncidenciaDto>(mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}