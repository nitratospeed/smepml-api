using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Seguimiento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IncidenciaId { get; set; }
        public Incidencia Incidencia { get; set; }
    }
}
