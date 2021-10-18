using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Core.Incidencias.Queries
{
    public class SeguimientoDto : IMapFrom<Seguimiento>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IncidenciaId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seguimiento, SeguimientoDto>().ReverseMap();
        }
    }
}
