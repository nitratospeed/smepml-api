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

namespace Application.Core.Diagnosticos.Queries
{
    public class GetDiagnosticosQuery : IRequest<PaginatedList<DiagnosticoDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string Nombres { get; set; }
        public string Dni { get; set; }
        public string Username { get; set; }
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
                .Where(x => (x.Paciente.Nombres.Contains(request.Nombres) || request.Nombres == null)
                    && (x.Paciente.Dni.Contains(request.Dni) || request.Dni == null)
                    && (x.CreadoPor == request.Username || request.Username == null))
                .OrderByDescending(x => x.Id)
                .ProjectTo<DiagnosticoDto>(mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
