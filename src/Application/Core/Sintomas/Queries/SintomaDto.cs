using Application.Common.Mappings;
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

    public class PreguntaDto : IMapFrom<Pregunta>
    {
        public int Id { get; set; }
        public int SintomaId { get; set; }
        public string Descripcion { get; set; }
        public List<OpcionDto> Opciones { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pregunta, PreguntaDto>();
        }
    }

    public class OpcionDto : IMapFrom<Opcion>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int PreguntaId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Opcion, OpcionDto>();
        }
    }
}
