using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Usuarios.Commands
{
    public class DeleteUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, int>
    {
        private readonly IAppDbContext context;

        public DeleteUsuarioCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Usuarios.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.Id);
            }

            entity.Estado = false;

            context.Usuarios.Update(entity);

            await context.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
