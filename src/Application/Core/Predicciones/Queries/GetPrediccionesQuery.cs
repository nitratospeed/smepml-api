using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Predicciones.Queries
{
    public class GetPrediccionesQuery : IRequest<PaginatedList<GetPrediccionesDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class GetPrediccionesQueryHandler : IRequestHandler<GetPrediccionesQuery, PaginatedList<GetPrediccionesDto>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetPrediccionesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PaginatedList<GetPrediccionesDto>> Handle(GetPrediccionesQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Diagnosticos.Include(x=>x.Paciente)
                .OrderByDescending(x=>x.Id)
                .ProjectTo<GetPrediccionesDto>(mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
