using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Diagnosticos.Queries
{
    public class DiagnosticoDto : IMapFrom<Diagnostico>
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string Condiciones { get; set; }
        public string Sintomas { get; set; }
        public string Preguntas { get; set; }
        public string Resultados { get; set; }
        public string ResultadoMasPreciso { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Diagnostico, DiagnosticoDto>();
        }
    }
}
