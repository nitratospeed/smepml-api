using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Preguntas.Queries
{
    public class PreguntaDto : IMapFrom<Pregunta>
    {
        public int Id { get; set; }
        public int SintomaId { get; set; }
        public string Descripcion { get; set; }
        public string OpcionEscogida { get; set; } = "";
        public List<OpcionDto> Opciones { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pregunta, PreguntaDto>();
        }
    }
}
