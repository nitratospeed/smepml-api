using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Core.Usuarios.Queries
{
    public class UsuarioDto : IMapFrom<Usuario>
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string NombreCompleto { get; set; }
        public PerfilEnum Perfil { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Usuario, UsuarioDto>();
        }
    }
}
