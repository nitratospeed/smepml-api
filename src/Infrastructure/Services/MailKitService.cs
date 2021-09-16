using Application.Common.Interfaces.Services;
using Domain.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MailKitService : IMailKitService
    {
        public async Task<bool> SendEmail(Diagnostico diagnostico, string correoDe, string contrasenaDe)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(correoDe));
            email.To.Add(MailboxAddress.Parse(diagnostico.Paciente.Correo));
            email.Subject = "Reporte pre-diagnóstico SMEPML";

            email.Body = new TextPart(TextFormat.Html)
            {
                Text =
                $"<h1>Hola {diagnostico.Paciente.Nombres} {diagnostico.Paciente.Apellidos}</h1>" +
                $"<hr>" +
                $"<h3>Este es el reporte del pre diagnostico #000{diagnostico.Id}</h3>" +
                $"<p>Sintomas presentados:</p>" +
                $"<p>{diagnostico.Sintomas}</p>" +
                $"<hr>" +
                $"<p>Resultados del pre-diagnóstico:</p>" +
                $"<p>{diagnostico.Resultados}</p>" +
                $"<hr>" +
                "<p>SMEPML</p>"
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(correoDe, contrasenaDe);
            smtp.Send(email);
            smtp.Disconnect(true);
            return await Task.FromResult(true);
        }
    }
}
