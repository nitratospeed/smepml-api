using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string NombreCompleto { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public DateTime? ActualizadoEn { get; set; }
        public string ActualizadoPor { get; set; }
        public bool Estado { get; set; }
    }
}
