using Application.Common.Exceptions;
using Application.Common.Interfaces;
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
            var entity = await context.Diagnosticos.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Diagnostico), request.Id);
            }

            var dto = new DiagnosticoDto
            {
                Id = entity.Id,
                Condiciones = entity.Condiciones,
                PacienteId = entity.PacienteId,
                Preguntas = entity.Preguntas,
                ResultadoMasPreciso = entity.ResultadoMasPreciso,
                Sintomas = entity.Sintomas,
                Resultados = entity.Resultados
            };

            return dto;
        }
    }
}
