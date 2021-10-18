using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Incidencias.Queries
{
    public class GetIncidenciasQuery : IRequest<PaginatedList<IncidenciaDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string Username { get; set; }
        public string Titulo { get; set; }
        public string Urgencia { get; set; }
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
            var result = await context.Incidencias.Include(x=>x.Seguimientos)
                .Where(x => (x.CreadoPor == request.Username || request.Username == null)
                && (x.Titulo.Contains(request.Titulo) || request.Titulo == null)
                && (x.Urgencia.Contains(request.Urgencia) || request.Urgencia == null))
                .OrderByDescending(x => x.Id)
                .ProjectTo<IncidenciaDto>(mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
