using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Diagnosticos.Commands
{
    public class EmailDiagnosticoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class EmailDiagnosticoCommandHandler : IRequestHandler<EmailDiagnosticoCommand, bool>
    {
        private readonly IMailKitService mailKitService;
        private readonly IAppDbContext context;

        public EmailDiagnosticoCommandHandler(IMailKitService mailKitService, IAppDbContext context)
        {
            this.mailKitService = mailKitService;
            this.context = context;
        }

        public async Task<bool> Handle(EmailDiagnosticoCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Diagnosticos.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Diagnostico), request.Id);
            }

            var correoDe = await context.Configuraciones.FirstOrDefaultAsync(x => x.Key == "CorreoDe");
            var contrasenaDe = await context.Configuraciones.FirstOrDefaultAsync(x => x.Key == "ContrasenaDe");

            return await mailKitService.SendEmail(entity.Paciente.Correo, correoDe.Value, contrasenaDe.Value);
        }
    }
}
