using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Incidencias.Commands
{
    public class UpdateIncidenciaCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Urgencia { get; set; } //enum
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string AdjuntoUrl { get; set; }
        public string Estado { get; set; } //enum
    }

    public class UpdateIncidenciaCommandHandler : IRequestHandler<UpdateIncidenciaCommand, int>
    {
        private readonly IAppDbContext context;

        public UpdateIncidenciaCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(UpdateIncidenciaCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Incidencias.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Incidencia), request.Id);
            }

            entity.Urgencia = request.Urgencia;
            entity.Titulo = request.Titulo;
            entity.Descripcion = request.Descripcion;
            entity.AdjuntoUrl = request.AdjuntoUrl;
            entity.Estado = request.Estado;
            entity.ActualizadoPor = "system";
            entity.ActualizadoEn = DateTime.Now;

            await context.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
