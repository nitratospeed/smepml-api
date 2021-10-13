using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Pacientes.Commands
{
    public class CreatePacienteCommand : IRequest<int>
    {
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

    public class CreatePacienteCommandHandler : IRequestHandler<CreatePacienteCommand, int>
    {
        private readonly IAppDbContext context;

        public CreatePacienteCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(CreatePacienteCommand request, CancellationToken cancellationToken)
        {
            var entity = new Paciente
            {
                Apellidos = request.Apellidos,
                Nombres = request.Nombres,
                Celular = request.Celular,
                Correo = request.Correo,
                Direccion = request.Direccion,
                Dni = request.Dni,
                Edad = request.Edad,
                FechaNacimiento = request.FechaNacimiento.Value,
                Genero = request.Genero,
                Estado = true,
            };

            context.Pacientes.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            var result = entity.Id;

            return result;
        }
    }
}
