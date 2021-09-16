using System.Collections.Generic;

namespace Domain.Entities
{
    public class Enfermedad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Recomendacion { get; set; }
        public List<Examen> Examenes { get; set; }
    }
}
