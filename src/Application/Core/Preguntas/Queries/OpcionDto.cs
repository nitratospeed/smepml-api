using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Preguntas.Queries
{
    public class OpcionDto : IMapFrom<Opcion>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Opcion, OpcionDto>();
        }
    }
}
