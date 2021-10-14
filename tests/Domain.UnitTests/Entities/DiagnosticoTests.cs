using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.UnitTests.Entities
{
    public class DiagnosticoTests
    {
        [Test]
        public void ShouldReturnValidCalificacion()
        {
            var diagnostico = new Diagnostico() { Calificacion = 5 };

            diagnostico.Calificacion.Should().BeGreaterOrEqualTo(1).And.BeLessOrEqualTo(5);
        }

        [Test]
        public void ShouldReturnInvalidCalificacion()
        {
            static void InvalidCalificacion()
            {
                var diagnostico = new Diagnostico() { Calificacion = 6 };

                diagnostico.Calificacion.Should().BeGreaterOrEqualTo(1).And.BeLessOrEqualTo(5);
            }

            Assert.Throws(typeof(AssertionException), InvalidCalificacion);
        }
    }
}
