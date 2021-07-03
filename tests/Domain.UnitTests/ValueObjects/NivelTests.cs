using Domain.Exceptions;
using Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.ValueObjects
{
    public class NivelTests
    {
        [Test]
        public void ShouldReturnSupportedNivel()
        {
            int numeroNivel = 1;

            int nivel = Nivel.From(numeroNivel);

            nivel.Should().Be(numeroNivel);
        }

        [Test]
        public void ShouldThrowUnsupportedNivelExceptionGivenNotSupportedNivel()
        {
            FluentActions.Invoking(() => Nivel.From(10))
                .Should().Throw<UnsupportedNivelException>();
        }
    }
}
