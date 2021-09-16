using Domain.Exceptions;
using Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.UnitTests.ValueObjects
{
    public class PacienteIdTests
    {
        [Test]
        public void ShouldReturnSupportedPacienteId()
        {
            int numeropacienteId = 1;

            int pacienteId = PacienteId.From(numeropacienteId);

            pacienteId.Should().Be(numeropacienteId);
        }

        [Test]
        public void ShouldThrowUnsupportedPacienteIdExceptionGivenNotSupportedPacienteId()
        {
            FluentActions.Invoking(() => PacienteId.From(0))
                .Should().Throw<UnsupportedPacienteIdException>();
        }
    }
}
