namespace Domain.Entities
{
    public class Opcion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }
    }
}
