using Domain.Entities;
using Domain.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.UnitTests.Entities
{
    public class UsuarioTests
    {
        [Test]
        public void ShouldReturnValidPerfil()
        {
            var diagnostico = new Usuario() { Perfil = PerfilEnum.Administrador };

            diagnostico.Perfil.Should().BeOfType<PerfilEnum>();
        }

        [Test]
        public void ShouldReturnInvalidPerfil()
        {
            static void InvalidPerfil()
            {
                var diagnostico = new Usuario() { Perfil = (PerfilEnum)3 };

                diagnostico.Perfil.Should().NotBeOfType<PerfilEnum>();
            }

            Assert.Throws(typeof(AssertionException), InvalidPerfil);
        }
    }
}
