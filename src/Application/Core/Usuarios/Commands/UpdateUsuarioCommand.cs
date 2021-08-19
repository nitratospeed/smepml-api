using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Usuarios.Commands
{
    public class UpdateUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string NombreCompleto { get; set; }
        public PerfilEnum Perfil { get; set; }
    }

    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, int>
    {
        private readonly IAppDbContext context;

        public UpdateUsuarioCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Usuarios.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Id);
            }

            entity.Correo = request.Correo;
            entity.Contrasena = request.Contrasena;
            entity.NombreCompleto = request.NombreCompleto;
            entity.Perfil = request.Perfil;
            entity.Estado = true;
            entity.ActualizadoPor = "system";
            entity.ActualizadoEn = DateTime.Now;

            await context.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
