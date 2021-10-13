﻿using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Incidencia : AuditableEntity
    {
        public int Id { get; set; }
        public string Urgencia { get; set; } //enum
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string AdjuntoUrl { get; set; }
        public string Estado { get; set; } //enum
    }
}
