using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Incidencias.Queries
{
    public class GetIncidenciaByIdQuery : IRequest<IncidenciaDto>
    {
        public int Id { get; set; }
    }

    public class GetIncidenciaByIdQueryHandler : IRequestHandler<GetIncidenciaByIdQuery, IncidenciaDto>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetIncidenciaByIdQueryHandler(IMapper mapper, IAppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<IncidenciaDto> Handle(GetIncidenciaByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Incidencias
                .Where(x => x.Id == request.Id)
                .ProjectTo<IncidenciaDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
