using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Pacientes.Commands
{
    public class UpdatePacienteValidator : AbstractValidator<UpdatePacienteCommand>
    {
        public UpdatePacienteValidator()
        {
            RuleFor(x => x.Apellidos)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.Nombres)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.Dni)
                .MaximumLength(8)
                .NotEmpty();

            RuleFor(x => x.Celular)
                .MaximumLength(9)
                .NotEmpty();

            RuleFor(x => x.FechaNacimiento)
                .NotEmpty();

            RuleFor(x => x.Correo)
                .MaximumLength(250)
                .NotEmpty();

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
