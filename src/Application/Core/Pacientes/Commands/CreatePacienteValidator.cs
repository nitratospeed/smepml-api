using Application.Common.Interfaces;
using FluentValidation;
using System.Linq;

namespace Application.Core.Pacientes.Commands
{
    public class CreatePacienteValidator : AbstractValidator<CreatePacienteCommand>
    {
        private readonly IAppDbContext context;
        public CreatePacienteValidator(IAppDbContext context)
        {
            this.context = context;

            RuleFor(x => x.Apellidos)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.Nombres)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.Dni)
                .MaximumLength(8)
                .NotEmpty()
                .Must(x => !context.Pacientes.Any(y => y.Dni == x)).WithMessage("El dni ingresado ya existe.");

            RuleFor(x => x.Celular)
                .MaximumLength(9)
                .NotEmpty();

            RuleFor(x => x.FechaNacimiento)
                .NotEmpty();

            RuleFor(x => x.Correo)
                .MaximumLength(250)
                .NotEmpty()
                .Must(x => !context.Pacientes.Any(y => y.Correo == x)).WithMessage("El correo ingresado ya existe.");

            RuleFor(x => x.Direccion)
                .MaximumLength(500)
                .NotEmpty();

            RuleFor(x => x.Edad)
                .InclusiveBetween(18, 75)
                .NotEmpty();

            RuleFor(x => x.Genero)
                .MaximumLength(1)
                .Must(x => x.Equals("M") || x.Equals("F"))
                .NotEmpty();
        }
    }
}
