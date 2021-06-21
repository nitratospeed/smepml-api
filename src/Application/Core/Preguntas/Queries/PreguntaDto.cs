using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Preguntas.Queries
{
    public class PreguntaDto
    {
        public int Id { get; set; }
        public int SintomaId { get; set; }
        public string Descripcion { get; set; }
        public List<OpcionDto> Opciones { get; set; }
    }
}
