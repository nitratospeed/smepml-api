using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Incidencias.Commands
{
    public class DeleteIncidenciaCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteIncidenciaCommandHandler : IRequestHandler<DeleteIncidenciaCommand, int>
    {
        private readonly IAppDbContext context;

        public DeleteIncidenciaCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(DeleteIncidenciaCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Incidencias.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Incidencia), request.Id);
            }

            entity.Estado = "Eliminado";

            context.Incidencias.Update(entity);

            await context.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
