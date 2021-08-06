using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Predicciones.Queries
{
    public class GetPrediccionesDto : IMapFrom<Diagnostico>
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Sintomas { get; set; }
        public string ResultadoMasPreciso { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Diagnostico, GetPrediccionesDto>()
                .ForMember(x => x.Nombres, y => y.MapFrom(z => z.Paciente.Nombres))
                .ForMember(x => x.Edad, y => y.MapFrom(z => z.Paciente.Edad))
                .ForMember(x => x.Genero, y => y.MapFrom(z => z.Paciente.Genero));
        }
    }
}
