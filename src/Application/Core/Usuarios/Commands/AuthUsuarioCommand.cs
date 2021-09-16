using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Usuarios.Commands
{
    public class AuthUsuarioCommand : IRequest<bool>
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }

    public class AuthUsuarioCommandHandler : IRequestHandler<AuthUsuarioCommand, bool>
    {
        private readonly IAppDbContext context;

        public AuthUsuarioCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(AuthUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Correo == request.Correo && x.Contrasena == request.Contrasena);

            if (usuario == null)
            {
                return false;
            }

            return true;
        }
    }
}
