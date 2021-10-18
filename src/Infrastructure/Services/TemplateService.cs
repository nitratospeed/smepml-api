using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class TemplateService : ITemplateService
    {
        public string GetTemplate(Diagnostico diagnostico, Enfermedad enfermedad)
        {
            var htmlBody =
                $"<h1>{diagnostico.Paciente.Nombres} {diagnostico.Paciente.Apellidos}</h1>" +
                $"<hr>" +
                $"<h3>Este es el reporte del pre diagnostico #000{diagnostico.Id}</h3>" +
                $"<p>Sintomas presentados:</p>";

            foreach (var item in diagnostico.Sintomas.Split(","))
            {
                htmlBody += $"<p>{item}</p>";
            }

            htmlBody += $"<hr>" +
            $"<p>Resultados del pre-diagnóstico:</p>";

            foreach (var item in diagnostico.Resultados.Split(","))
            {
                htmlBody += $"<p>{item}</p>";
            }

            htmlBody += $"<hr>" +
            $"<p>Recomendaciones sugeridas:</p>";
            htmlBody += $"<p>{enfermedad.Recomendacion}</p>";

            htmlBody += $"<hr>" +
            $"<p>Exámenes sugeridos:</p>";

            foreach (var item in enfermedad.Examenes)
            {
                htmlBody += $"<p>{item.Nombre}</p>";
            }

            htmlBody += $"<hr>" +
                $"<p>SMEPML</p>";

            return htmlBody;
        }
    }
}
