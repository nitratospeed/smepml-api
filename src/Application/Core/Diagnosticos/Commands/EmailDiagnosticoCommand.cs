using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly ITemplateService templateService;
        private readonly IAppDbContext context;

        public EmailDiagnosticoCommandHandler(IMailKitService mailKitService, IAppDbContext context, ITemplateService templateService)
        {
            this.mailKitService = mailKitService;
            this.context = context;
            this.templateService = templateService;
        }

        public async Task<bool> Handle(EmailDiagnosticoCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Diagnosticos.Include(x => x.Paciente).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Diagnostico), request.Id);
            }

            var correoDe = await context.Configuraciones.FirstOrDefaultAsync(x => x.Key == "CorreoDe");
            var contrasenaDe = await context.Configuraciones.FirstOrDefaultAsync(x => x.Key == "ContrasenaDe");

            var enfermedad = await context.Enfermedades.Include(x => x.Examenes).FirstOrDefaultAsync(x => x.Nombre.ToLower() == entity.ResultadoMasPreciso.ToLower());

            var htmlAdjunto = templateService.GetTemplate(entity, enfermedad);

            return await mailKitService.SendEmail(htmlAdjunto, entity, correoDe.Value, contrasenaDe.Value);
        }
    }
}
