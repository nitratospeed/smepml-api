using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Diagnosticos.Commands
{
    public class CreateDiagnosticoCommand : IRequest<int>
    {
        public int PacienteId { get; set; }
        public string Condiciones { get; set; }
        public string Sintomas { get; set; }
        public string Preguntas { get; set; }
        public string Resultados { get; set; }
        public string ResultadoMasPreciso { get; set; }
    }

    public class CreateDiagnosticoCommandHandler : IRequestHandler<CreateDiagnosticoCommand, int>
    {
        private readonly IAppDbContext context;

        public CreateDiagnosticoCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(CreateDiagnosticoCommand request, CancellationToken cancellationToken)
        {
            var entity = new Diagnostico
            {
                PacienteId = request.PacienteId,
                Preguntas = request.Preguntas,
                ResultadoMasPreciso = request.ResultadoMasPreciso,
                Condiciones = request.Condiciones,
                Sintomas = request.Sintomas,
                Resultados = request.Resultados,
                CreadoPor = "system",
                CreadoEn = DateTime.UtcNow.AddHours(-5)
            };

            context.Diagnosticos.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            var result = entity.Id;

            return result;
        }
    }
}
