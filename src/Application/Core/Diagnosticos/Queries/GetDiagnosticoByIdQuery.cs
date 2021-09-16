using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Diagnosticos.Queries
{
    public class GetDiagnosticoByIdQuery : IRequest<DiagnosticoDto>
    {
        public int Id { get; set; }
    }

    public class GetDiagnosticoByIdQueryHandler : IRequestHandler<GetDiagnosticoByIdQuery, DiagnosticoDto>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetDiagnosticoByIdQueryHandler(IMapper mapper, IAppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<DiagnosticoDto> Handle(GetDiagnosticoByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await context.Diagnosticos.Include(x => x.Paciente).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Diagnostico), request.Id);
            }

            var dto = mapper.Map<DiagnosticoDto>(entity);

            return dto;
        }
    }
}
