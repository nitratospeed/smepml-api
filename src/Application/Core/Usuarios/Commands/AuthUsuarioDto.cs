namespace Application.Core.Usuarios.Commands
{
    public class AuthUsuarioDto
    {
        public bool Valid { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }
    }
}
