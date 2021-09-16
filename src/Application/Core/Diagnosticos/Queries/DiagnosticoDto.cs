using Application.Common.Mappings;
using Application.Core.Pacientes.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Core.Diagnosticos.Queries
{
    public class DiagnosticoDto : IMapFrom<Diagnostico>
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public PacienteDto Paciente { get; set; }
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
