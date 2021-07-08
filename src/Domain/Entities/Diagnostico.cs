using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public string Condiciones { get; set; }
        public string Preguntas { get; set; }
        public string Sintomas { get; set; }
        public string ResultadoMasPreciso { get; set; }
    }
}
