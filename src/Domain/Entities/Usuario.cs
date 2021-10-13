using Domain.Common;
using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Usuario : AuditableEntity
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string NombreCompleto { get; set; }
        public PerfilEnum Perfil { get; set; }
        public bool Estado { get; set; }
    }
}
