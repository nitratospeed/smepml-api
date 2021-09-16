using FluentValidation;

namespace Application.Core.Usuarios.Commands
{
    public class CreateUsuarioValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioValidator()
        {
            RuleFor(x => x.Correo)
               .MaximumLength(250)
               .NotEmpty()
               .EmailAddress();

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
