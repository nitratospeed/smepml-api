using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Diagnosticos.Queries
{
    public class PdfDiagnosticoByIdQuery : IRequest<byte[]>
    {
        public int Id { get; set; }
    }
    public class PdfDiagnosticoByIdQueryHandler : IRequestHandler<PdfDiagnosticoByIdQuery, byte[]>
    {
        private readonly IAppDbContext context;
        private readonly IPdfService pdfService;
        private readonly ITemplateService templateService;
        private readonly IMapper mapper;

        public PdfDiagnosticoByIdQueryHandler(IAppDbContext context, IMapper mapper, IPdfService pdfService, ITemplateService templateService)
        {
            this.context = context;
            this.mapper = mapper;
            this.pdfService = pdfService;
            this.templateService = templateService;
        }

        public async Task<byte[]> Handle(PdfDiagnosticoByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await context.Diagnosticos.Include(x => x.Paciente).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Diagnostico), request.Id);
            }

            var enfermedad = await context.Enfermedades.Include(x => x.Examenes).FirstOrDefaultAsync(x => x.Nombre.ToLower() == entity.ResultadoMasPreciso.ToLower());

            var htmlBody = templateService.GetTemplate(entity, enfermedad);

            var result = pdfService.GetPdf(htmlBody);

            return result.ToArray();
        }
    }
}
