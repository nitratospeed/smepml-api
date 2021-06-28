using Application.Common.Mappings;
using Application.Core.Preguntas.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Sintomas.Queries
{
    public class SintomaDto : IMapFrom<Sintoma>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool HasPreguntas { get; set; }
        public int ZonaId { get; set; }
        public List<PreguntaDto> Preguntas { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sintoma, SintomaDto>();
        }
    }
}
