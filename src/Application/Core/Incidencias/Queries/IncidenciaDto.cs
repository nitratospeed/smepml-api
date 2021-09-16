using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Core.Incidencias.Queries
{
    public class IncidenciaDto : IMapFrom<Incidencia>
    {
        public int Id { get; set; }
        public string Urgencia { get; set; } //enum
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string AdjuntoUrl { get; set; }
        public string Estado { get; set; } //enum

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Incidencia, IncidenciaDto>();
        }
    }
}
