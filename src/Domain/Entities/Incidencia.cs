using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Incidencia
    {
        public int Id { get; set; }
        public string Urgencia { get; set; } //enum
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string AdjuntoUrl { get; set; }
        public string Estado { get; set; } //enum
        public DateTime CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public DateTime? ActualizadoEn { get; set; }
        public string ActualizadoPor { get; set; }
    }
}
