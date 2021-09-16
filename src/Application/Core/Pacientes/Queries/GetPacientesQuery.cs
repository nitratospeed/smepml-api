using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Pacientes.Queries
{
    public class GetPacientesQuery : IRequest<PaginatedList<PacienteDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string Dni { get; set; } = "";
    }

    public class GetPacientesQueryHandler : IRequestHandler<GetPacientesQuery, PaginatedList<PacienteDto>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetPacientesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PaginatedList<PacienteDto>> Handle(GetPacientesQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Pacientes
                .Where(x => x.Dni == request.Dni || request.Dni == "")
                .OrderByDescending(x => x.Id)
                .ProjectTo<PacienteDto>(mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
