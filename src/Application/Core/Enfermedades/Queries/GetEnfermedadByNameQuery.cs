using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Enfermedades.Queries
{
    public class GetEnfermedadByNameQuery : IRequest<EnfermedadDto>
    {
        public string Nombre { get; set; }
    }

    public class GetEnfermedadByNameQueryHandler : IRequestHandler<GetEnfermedadByNameQuery, EnfermedadDto>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetEnfermedadByNameQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<EnfermedadDto> Handle(GetEnfermedadByNameQuery request, CancellationToken cancellationToken)
        {
            var enfermedad = await context.Enfermedades.FirstOrDefaultAsync(x => x.Nombre.ToLower() == request.Nombre.ToLower());

            if (enfermedad == null)
            {
                throw new NotFoundException(nameof(Enfermedad), request.Nombre);
            }

            return mapper.Map<EnfermedadDto>(enfermedad);
        }
    }
}
