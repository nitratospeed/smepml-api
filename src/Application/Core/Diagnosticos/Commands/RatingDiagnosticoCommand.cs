using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Diagnosticos.Commands
{
    public class RatingDiagnosticoCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int Calificacion { get; set; }
    }
    public class RatingDiagnosticoCommandHandler : IRequestHandler<RatingDiagnosticoCommand, bool>
    {
        private readonly IAppDbContext context;

        public RatingDiagnosticoCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(RatingDiagnosticoCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Diagnosticos.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Diagnostico), request.Id);
            }

            entity.Calificacion = request.Calificacion;

            await context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
