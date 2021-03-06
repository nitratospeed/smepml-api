using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Enfermedades.Queries
{
    public class GetEnfermedadByNombreQuery : IRequest<EnfermedadDto>
    {
        public string Nombre { get; set; }
    }

    public class GetEnfermedadByNombreQueryHandler : IRequestHandler<GetEnfermedadByNombreQuery, EnfermedadDto>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetEnfermedadByNombreQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<EnfermedadDto> Handle(GetEnfermedadByNombreQuery request, CancellationToken cancellationToken)
        {
            var enfermedad = await context.Enfermedades.Include(x => x.Examenes).FirstOrDefaultAsync(x => x.Nombre.ToLower() == request.Nombre.ToLower());

            if (enfermedad == null)
            {
                throw new NotFoundException(nameof(Enfermedad), request.Nombre);
            }

            return mapper.Map<EnfermedadDto>(enfermedad);
        }
    }
}
