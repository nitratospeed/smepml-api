using Application.Common.Interfaces;
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

namespace Application.Core.Preguntas.Queries
{
    public class GetPreguntasQuery : IRequest<List<PreguntaDto>>
    {
        public int SintomaId { get; set; }
    }

    public class GetPreguntasQueryHandler : IRequestHandler<GetPreguntasQuery, List<PreguntaDto>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext context;

        public GetPreguntasQueryHandler(IMapper mapper, IAppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<PreguntaDto>> Handle(GetPreguntasQuery request, CancellationToken cancellationToken)
        {
            var preguntas = await context.Preguntas.Where(x=>x.SintomaId == request.SintomaId).ToListAsync();

            var preguntasConOpciones = new List<PreguntaDto>();

            foreach (var item in preguntas)
            {
                var opciones = await context.Opciones.Where(x => x.PreguntaId == item.Id).ToListAsync();

                var preguntaConOpciones = new PreguntaDto
                {
                    Descripcion = item.Descripcion,
                    Id = item.Id,
                    SintomaId = item.SintomaId,
                    Opciones = mapper.Map<List<OpcionDto>>(opciones)
                };

                preguntasConOpciones.Add(preguntaConOpciones);
            }

            return preguntasConOpciones;
        }
    }
}
