using FluentValidation;
using System.IO;

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

            When(x => x.AdjuntoUrl != null, () =>
            {
                RuleFor(x => x.AdjuntoUrl.Length)
                   .NotNull()
                   .LessThanOrEqualTo(10485760)
                   .WithMessage("El tamaño del archivo sobrepasa los 10mb");

                RuleFor(x => Path.GetExtension(x.AdjuntoUrl.FileName))
                   .Must(x => x.ToLower().Contains("jpg") || x.ToLower().Contains("jpeg") || x.ToLower().Contains("png") || x.ToLower().Contains("pdf"))
                   .WithMessage("Tipo de archivo no admitido. Archivos admitidos: .jpg, .jpeg, .png o .pdf");
            });

            RuleFor(x => x.Estado)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
