using Domain.Common;

namespace Domain.Entities
{
    public class Diagnostico : AuditableEntity
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public string Condiciones { get; set; }
        public string Sintomas { get; set; }
        public string Preguntas { get; set; }
        public string Resultados { get; set; }
        public string ResultadoMasPreciso { get; set; }
        public int Calificacion { get; set; }
    }
}
