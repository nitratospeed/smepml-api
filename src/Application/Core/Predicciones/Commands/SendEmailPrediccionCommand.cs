using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Predicciones.Commands
{
    public class SendEmailPrediccionCommand : IRequest<bool>
    {
        public int UsuarioId { get; set; }
    }

    public class SendEmailPrediccionCommandHandler : IRequestHandler<SendEmailPrediccionCommand, bool>
    {
        private readonly IMailKitService mailKitService;
        private readonly IAppDbContext context;

        public SendEmailPrediccionCommandHandler(IMailKitService mailKitService, IAppDbContext context)
        {
            this.mailKitService = mailKitService;
            this.context = context;
        }

        public async Task<bool> Handle(SendEmailPrediccionCommand request, CancellationToken cancellationToken)
        {
            var usuario = await context.Usuarios.FindAsync(request.UsuarioId);

            if (usuario == null)
            {
                throw new NotFoundException(nameof(Usuario), request.UsuarioId);
            }

            var correoDe = await context.Configuraciones.FirstOrDefaultAsync(x => x.Key == "CorreoDe");
            var contrasenaDe = await context.Configuraciones.FirstOrDefaultAsync(x => x.Key == "ContrasenaDe");

            return await mailKitService.SendEmail(usuario.Correo, correoDe.Value, contrasenaDe.Value);
        }
    }
}
