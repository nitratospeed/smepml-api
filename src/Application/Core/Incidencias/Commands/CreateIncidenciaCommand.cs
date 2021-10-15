using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Incidencias.Commands
{
    public class CreateIncidenciaCommand : IRequest<int>
    {
        public string Urgencia { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public IFormFile AdjuntoUrl { get; set; }
        public string Estado { get; set; }
    }

    public class CreateIncidenciaCommandHandler : IRequestHandler<CreateIncidenciaCommand, int>
    {
        private readonly IAppDbContext context;
        private readonly IAzureBlobService azureBlobService;

        public CreateIncidenciaCommandHandler(IAppDbContext context, IAzureBlobService azureBlobService)
        {
            this.context = context;
            this.azureBlobService = azureBlobService;
        }

        public async Task<int> Handle(CreateIncidenciaCommand request, CancellationToken cancellationToken)
        {
            byte[] adjuntoFile;

            using (var stream = new MemoryStream())
            {
                await request.AdjuntoUrl.CopyToAsync(stream, cancellationToken);
                adjuntoFile = stream.ToArray();
            }

            var adjuntoUrl = await azureBlobService.Upload("/", request.AdjuntoUrl.FileName, adjuntoFile);

            var entity = new Incidencia
            {
                Urgencia = request.Urgencia,
                Titulo = request.Titulo,
                Descripcion = request.Descripcion,
                AdjuntoUrl = adjuntoUrl,
                Estado = request.Estado,
            };

            context.Incidencias.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            var result = entity.Id;

            return result;
        }
    }
}
