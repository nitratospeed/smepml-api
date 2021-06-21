﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Sintoma
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nivel { get; set; }
        public bool HasNivel { get; set; }
        public List<Pregunta> Preguntas { get; set; }
    }
}
