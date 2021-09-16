using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Core.Pacientes.Queries
{
    public class PacienteDto : IMapFrom<Paciente>
    {
        public int Id { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Dni { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        //public List<Diagnostico> Diagnosticos { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Paciente, PacienteDto>();
        }
    }
}
