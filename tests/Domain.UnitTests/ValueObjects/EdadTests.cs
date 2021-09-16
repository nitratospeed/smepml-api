using Domain.Exceptions;
using Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.UnitTests.ValueObjects
{
    public class EdadTests
    {
        [Test]
        public void ShouldReturnSupportedEdad()
        {
            int numeroEdad = 26;

            int edad = Edad.From(numeroEdad);

            edad.Should().Be(numeroEdad);
        }

        [Test]
        public void ShouldThrowUnsupportedEdadExceptionGivenNotSupportedEdad()
        {
            FluentActions.Invoking(() => Edad.From(10))
                .Should().Throw<UnsupportedEdadException>();
        }
    }
}
