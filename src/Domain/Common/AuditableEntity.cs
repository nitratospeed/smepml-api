using System;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public DateTime? ActualizadoEn { get; set; }
        public string ActualizadoPor { get; set; }
    }
}
