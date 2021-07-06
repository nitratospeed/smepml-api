using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string NombresApellidos { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public List<Diagnostico> Diagnosticos { get; set; }
    }
}
