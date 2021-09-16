using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System.Linq;

namespace Application.Core.Enfermedades.Queries
{
    public class EnfermedadDto : IMapFrom<Enfermedad>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Recomendacion { get; set; }
        public string[] Examenes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Enfermedad, EnfermedadDto>()
                .ForMember(dest => dest.Examenes, opt => opt.MapFrom(src => src.Examenes.Select(x => x.Nombre).ToArray()));
        }
    }
}
