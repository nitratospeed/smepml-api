using System.Collections.Generic;

namespace Domain.Entities
{
    public class Pregunta
    {
        public int Id { get; set; }
        public int SintomaId { get; set; }
        public Sintoma Sintoma { get; set; }
        public string Descripcion { get; set; }
        public List<Opcion> Opciones { get; set; }
    }
}
