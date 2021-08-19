using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Usuarios.Commands
{
    public class UpdateUsuarioValidator : AbstractValidator<UpdateUsuarioCommand>
    {
        public UpdateUsuarioValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty();

            RuleFor(x => x.Correo)
               .MaximumLength(250)
               .NotEmpty();

            RuleFor(x => x.Contrasena)
               .MaximumLength(250)
               .NotEmpty();

            RuleFor(x => x.NombreCompleto)
               .MaximumLength(250)
               .NotEmpty();

            RuleFor(x => x.Perfil)
               .IsInEnum()
               .NotEmpty();
        }
    }
}
