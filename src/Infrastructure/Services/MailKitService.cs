using Application.Common.Interfaces;
using Domain.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MailKitService : IMailKitService
    {
        private readonly IPdfService pdfService;

        public MailKitService(IPdfService pdfService)
        {
            this.pdfService = pdfService;
        }

        public async Task<bool> SendEmail(string html, Diagnostico diagnostico, string correoDe, string contrasenaDe)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(correoDe));
            email.To.Add(MailboxAddress.Parse(diagnostico.Paciente.Correo));
            email.Subject = "Reporte pre-diagnóstico SMEPML";

            var builder = new BodyBuilder();

            var htmlBody =
                $"<h1>Hola, {diagnostico.Paciente.Nombres} {diagnostico.Paciente.Apellidos}</h1>" +
                $"<br>" +
                $"<h3>Te adjuntamos el reporte de tu pre diagnóstico #000{diagnostico.Id}, realizado por el sistema SMEPML.</h3>" +
                $"<br>" +
                $"<p>Saludos.</p>" +
                $"<br>" +
                $"<p>Por favor NO RESPONDER a esta dirección de correo electrónico pues se trata de un buzón como 'solo salida'," +
                $" aún cuando no reciba mensajes de error, su correo no va a ser atendido." +
                $" Sus consultas podrán ser atendidas solo por su médico Gastroenterólogo en las citas presenciales.</p>" +
                $"<br>" +
                $"<p>SMEPML</p>";

            builder.HtmlBody = htmlBody;

            var htmlByte = pdfService.GetPdf(html);

            builder.Attachments.Add($"reporte_000{diagnostico.Id}.pdf", htmlByte);

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(correoDe, contrasenaDe);
            smtp.Send(email);
            smtp.Disconnect(true);
            return await Task.FromResult(true);
        }
    }
}
