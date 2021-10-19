using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Core.Incidencias.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Incidencias.Commands
{
    public class UpdateIncidenciaCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Urgencia { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string AdjuntoUrl { get; set; }
        public string Estado { get; set; }
        public List<SeguimientoDto> Seguimientos { get; set; }
    }

    public class UpdateIncidenciaCommandHandler : IRequestHandler<UpdateIncidenciaCommand, int>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public UpdateIncidenciaCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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

            if (request.Seguimientos.Any())
            {
                foreach (var item in request.Seguimientos.Where(x=>x.Id == 0))
                {
                    var seguimiento = mapper.Map<Seguimiento>(item);
                    seguimiento.IncidenciaId = entity.Id;
                    await context.Seguimientos.AddAsync(seguimiento);
                }
            }

            await context.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
