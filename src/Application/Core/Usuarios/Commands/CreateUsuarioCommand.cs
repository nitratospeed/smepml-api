using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Usuarios.Commands
{
    public class CreateUsuarioCommand : IRequest<int>
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string NombreCompleto { get; set; }
        public PerfilEnum Perfil { get; set; }
    }

    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IAppDbContext context;

        public CreateUsuarioCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = new Usuario
            {
                Correo = request.Correo,
                Contrasena = request.Contrasena,
                NombreCompleto = request.NombreCompleto,
                Perfil = request.Perfil,
                Estado = true,
            };

            context.Usuarios.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            var result = entity.Id;

            return result;
        }
    }
}
