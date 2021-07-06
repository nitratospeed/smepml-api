using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
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
        private readonly IPreguntaRepository preguntaRepository;
        private readonly IOpcionRepository opcionRepository;

        public GetPreguntasQueryHandler(IMapper mapper, IPreguntaRepository preguntaRepository, IOpcionRepository opcionRepository)
        {
            this.mapper = mapper;
            this.preguntaRepository = preguntaRepository;
            this.opcionRepository = opcionRepository;
        }

        public async Task<List<PreguntaDto>> Handle(GetPreguntasQuery request, CancellationToken cancellationToken)
        {
            var preguntas = await preguntaRepository.GetSearch(x=>x.SintomaId == request.SintomaId);

            var preguntasConOpciones = new List<PreguntaDto>();

            foreach (var item in preguntas)
            {
                var opciones = await opcionRepository.GetSearch(x => x.PreguntaId == item.Id);

                var preguntaConOpciones = new PreguntaDto
                {
                    Descripcion = item.Descripcion,
                    Id = item.Id,
                    SintomaId = item.SintomaId,
                    Opciones = opciones.AsQueryable().ProjectTo<OpcionDto>(mapper.ConfigurationProvider).ToList()
                };

                preguntasConOpciones.Add(preguntaConOpciones);
            }

            return preguntasConOpciones;
        }
    }
}
