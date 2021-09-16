using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Pacientes.Commands
{
    public class UpdatePacienteCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Dni { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
    }

    public class UpdatePacienteCommandHandler : IRequestHandler<UpdatePacienteCommand, int>
    {
        private readonly IAppDbContext context;

        public UpdatePacienteCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(UpdatePacienteCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Pacientes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Paciente), request.Id);
            }

            entity.Apellidos = request.Apellidos;
            entity.Nombres = request.Nombres;
            entity.Celular = request.Celular;
            entity.Correo = request.Correo;
            entity.Direccion = request.Direccion;
            entity.Dni = request.Dni;
            entity.Edad = request.Edad;
            entity.FechaNacimiento = request.FechaNacimiento;
            entity.Genero = request.Genero;
            entity.Estado = true;

            await context.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
