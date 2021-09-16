using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Pacientes.Queries
{
    public class GetPacienteByIdQuery : IRequest<PacienteDto>
    {
        public int Id { get; set; }
    }

    public class GetPacienteByIdQueryHandler : IRequestHandler<GetPacienteByIdQuery, PacienteDto>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetPacienteByIdQueryHandler(IMapper mapper, IAppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<PacienteDto> Handle(GetPacienteByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Pacientes
                .Where(x => x.Id == request.Id)
                .ProjectTo<PacienteDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
