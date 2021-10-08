using Application.Common.Interfaces;
using FluentValidation;
using System.Linq;

namespace Application.Core.Usuarios.Commands
{
    public class CreateUsuarioValidator : AbstractValidator<CreateUsuarioCommand>
    {
        private readonly IAppDbContext context;
        public CreateUsuarioValidator(IAppDbContext context)
        {
            this.context = context;

            RuleFor(x => x.Correo)
               .MaximumLength(250)
               .NotEmpty()
               .EmailAddress()
               .Must(x => !context.Pacientes.Any(y => y.Correo == x)).WithMessage("El correo ingresado ya existe.");

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
