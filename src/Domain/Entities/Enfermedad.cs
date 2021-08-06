﻿using System;
using System.Collections.Generic;
using System.Text;

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
