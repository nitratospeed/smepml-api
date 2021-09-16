using FluentValidation;

namespace Application.Core.Incidencias.Commands
{
    public class UpdateIncidenciaValidator : AbstractValidator<UpdateIncidenciaCommand>
    {
        public UpdateIncidenciaValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Urgencia)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.Titulo)
                .MaximumLength(250)
                .NotEmpty();

            RuleFor(x => x.AdjuntoUrl)
                .MaximumLength(250)
                .NotEmpty();

            RuleFor(x => x.Estado)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
