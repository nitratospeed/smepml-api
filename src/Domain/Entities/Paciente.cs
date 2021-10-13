using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Paciente : AuditableEntity
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
        public bool Estado { get; set; }
        public List<Diagnostico> Diagnosticos { get; set; }
    }
}
