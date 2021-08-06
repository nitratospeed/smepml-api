using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Examen
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EnfermedadId { get; set; }
        public Enfermedad Enfermedad { get; set; }
    }
}
