using Application.Core.Usuarios.Commands;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Core.Usuarios.Queries
{
    using static Testing;
    public class AuthUsuarioTests
    {
        [Test]
        public async Task ShouldAuthUsuario()
        {
            //arrange
            var command = new AuthUsuarioCommand
            {
                Correo = "u201817688@upc.edu.pe",
                Contrasena = "1234"
            };

            //act
            var result = await SendAsync(command);

            //assert (lo q deberia cumplir)
            result.Valid.Should().Be(true);
        }
    }
}
