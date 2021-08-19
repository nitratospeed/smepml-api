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
    public class CreateIncidenciaCommand : IRequest<int>
    {
        public string Urgencia { get; set; } //enum
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string AdjuntoUrl { get; set; }
        public string Estado { get; set; } //enum
    }

    public class CreateIncidenciaCommandHandler : IRequestHandler<CreateIncidenciaCommand, int>
    {
        private readonly IAppDbContext context;

        public CreateIncidenciaCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(CreateIncidenciaCommand request, CancellationToken cancellationToken)
        {
            var entity = new Incidencia
            {
                Urgencia = request.Urgencia,
                Titulo = request.Titulo,
                Descripcion = request.Descripcion,
                AdjuntoUrl = request.AdjuntoUrl,
                Estado = request.Estado,
                CreadoPor = "system",
                CreadoEn = DateTime.Now
            };

            context.Incidencias.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            var result = entity.Id;

            return result;
        }
    }
}
