using Application.Common.Interfaces.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MailKitService : IMailKitService
    {
        public async Task<bool> SendEmail(string correo, string correoDe, string contrasenaDe)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(correoDe));
            email.To.Add(MailboxAddress.Parse(correo));
            email.Subject = "Reporte SMEPML";

            email.Body = new TextPart(TextFormat.Html)
            {
                //Text =
                //"<h1>Hola " + usuario.Nombres + " " + usuario.Apellidos + "</h1>" +
                //"<img src='" + curso.UrlImagen + "' width='224' height='240'>" +
                //"<h1>Bienvenido al curso de " + curso.Nombre + "</h1>" +
                //"<p> " + curso.Descripcion + "</p> " +
                //"<p> Docente: " + curso.Docente.Nombre + "</p> " +
                //"<a href='" + curso.UrlVideo + "'>Podrás ingresar al curso aquí</a>" +
                //"<p>Grupo 5 - Ágiles 2021</p>"
                Text = $"Hola {correo}!"
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
