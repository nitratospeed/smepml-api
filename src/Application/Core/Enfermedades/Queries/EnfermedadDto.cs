using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Enfermedades.Queries
{
    public class EnfermedadDto : IMapFrom<Enfermedad>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Enfermedad, EnfermedadDto>();
        }
    }
}
