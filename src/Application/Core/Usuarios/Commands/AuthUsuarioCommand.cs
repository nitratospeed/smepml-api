using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Application.Common.Models;
using Domain.Enums;

namespace Application.Core.Usuarios.Commands
{
    public class AuthUsuarioCommand : IRequest<AuthUsuarioDto>
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }

    public class AuthUsuarioCommandHandler : IRequestHandler<AuthUsuarioCommand, AuthUsuarioDto>
    {
        private readonly IAppDbContext context;

        public AuthUsuarioCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<AuthUsuarioDto> Handle(AuthUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Correo == request.Correo && x.Contrasena == request.Contrasena);

            if (usuario == null)
            {
                return new AuthUsuarioDto { Valid = false };
            }

            var token = GenerateJwtToken(usuario);

            return new AuthUsuarioDto { Valid = true, Usuario = usuario.NombreCompleto, Token = token };
        }

        private string GenerateJwtToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettingsKeys.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = AppSettingsKeys.Issuer,
                Issuer = AppSettingsKeys.Issuer,
                Subject = new ClaimsIdentity(new[] { 
                    new Claim("perfil", Enum.GetName(typeof(PerfilEnum), user.Perfil)),
                    new Claim("username", user.Correo)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
