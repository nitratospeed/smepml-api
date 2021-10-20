using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Core.Incidencias.Queries
{
    public class IncidenciaDto : IMapFrom<Incidencia>
    {
        public int Id { get; set; }
        public string Urgencia { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string AdjuntoUrl { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public List<SeguimientoDto> Seguimientos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Incidencia, IncidenciaDto>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.CreadoPor));
        }
    }
}
