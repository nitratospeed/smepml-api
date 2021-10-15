using FluentValidation;

namespace Application.Core.Incidencias.Commands
{
    public class CreateIncidenciaValidator : AbstractValidator<CreateIncidenciaCommand>
    {
        public CreateIncidenciaValidator()
        {
            RuleFor(x => x.Urgencia)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.Titulo)
                .MaximumLength(250)
                .NotEmpty();

            RuleFor(x => x.AdjuntoUrl)
                .NotEmpty();

            RuleFor(x => x.Estado)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
