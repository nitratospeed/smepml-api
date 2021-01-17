using System;
using System.Collections.Generic;
using System.Text;

namespace SMEPMLBack.Core.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
    }
}
