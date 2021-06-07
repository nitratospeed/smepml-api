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
        public string Nivel { get; set; }
        public bool HasNivel { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sintoma, SintomaDto>();
        }
    }
}
