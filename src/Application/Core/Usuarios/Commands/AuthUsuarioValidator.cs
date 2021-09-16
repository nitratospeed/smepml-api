using FluentValidation;

namespace Application.Core.Usuarios.Commands
{
    public class AuthUsuarioValidator : AbstractValidator<AuthUsuarioCommand>
    {
        public AuthUsuarioValidator()
        {
            RuleFor(x => x.Correo)
               .MaximumLength(250)
               .NotEmpty()
               .EmailAddress();

            RuleFor(x => x.Contrasena)
               .MaximumLength(250)
               .NotEmpty();
        }
    }
}
