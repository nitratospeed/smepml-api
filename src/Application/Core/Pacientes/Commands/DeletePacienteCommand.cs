using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Pacientes.Commands
{
    public class DeletePacienteCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeletePacienteCommandHandler : IRequestHandler<DeletePacienteCommand, int>
    {
        private readonly IAppDbContext context;

        public DeletePacienteCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(DeletePacienteCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Pacientes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Paciente), request.Id);
            }

            entity.Estado = false;

            context.Pacientes.Update(entity);

            await context.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
