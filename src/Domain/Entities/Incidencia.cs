using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Incidencia : AuditableEntity
    {
        public int Id { get; set; }
        public string Urgencia { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string AdjuntoUrl { get; set; }
        public string Estado { get; set; }
        public List<Seguimiento> Seguimientos { get; set; }
    }
}
