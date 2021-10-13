using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public DateTime? FechaNacimiento { get; set; }
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

            if (entity.Correo != request.Correo)
            {
                if (context.Pacientes.Any(x => x.Correo == request.Correo))
                {
                    throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("Correo", "El correo ingresado ya existe.") });
                }
            }

            if (entity.Dni != request.Dni)
            {
                if (context.Pacientes.Any(x => x.Dni == request.Dni))
                {
                    throw new ValidationException(new List<ValidationFailure>() { new ValidationFailure("Dni", "El dni ingresado ya existe.") });
                }
            }

            entity.Apellidos = request.Apellidos;
            entity.Nombres = request.Nombres;
            entity.Celular = request.Celular;
            entity.Correo = request.Correo;
            entity.Direccion = request.Direccion;
            entity.Dni = request.Dni;
            entity.Edad = request.Edad;
            entity.FechaNacimiento = request.FechaNacimiento.Value;
            entity.Genero = request.Genero;
            entity.Estado = true;

            await context.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}
