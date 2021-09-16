using System.Collections.Generic;

namespace Domain.Entities
{
    public class Sintoma
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool HasPreguntas { get; set; }
        public int ZonaId { get; set; }
        public List<Pregunta> Preguntas { get; set; }
    }
}
