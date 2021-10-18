using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Domain.UnitTests.Entities
{
    public class PacienteTests
    {
        [Test]
        public void ShouldReturnValidEdad()
        {
            var paciente = new Paciente() { Edad = 27 };

            paciente.Edad.Should().BeGreaterOrEqualTo(18).And.BeLessOrEqualTo(75);
        }

        [Test]
        public void ShouldReturnInvalidEdad()
        {
            static void InvalidEdad()
            {
                var paciente = new Paciente() { Edad = 10 };

                paciente.Edad.Should().BeGreaterOrEqualTo(18).And.BeLessOrEqualTo(75);
            }

            Assert.Throws(typeof(AssertionException), InvalidEdad);
        }

        [Test]
        public void ShouldReturnValidDni()
        {
            var paciente = new Paciente() { Dni = "72607240" };

            paciente.Dni.Should().HaveLength(8);
        }

        [Test]
        public void ShouldReturnInvalidDni()
        {
            static void InvalidDni()
            {
                var paciente = new Paciente() { Dni = "0000" };

                paciente.Dni.Should().HaveLength(8);
            }

            Assert.Throws(typeof(AssertionException), InvalidDni);
        }

        [Test]
        public void ShouldReturnValidGenero()
        {
            List<string> conditions = new List<string>() { "M", "F" };

            var paciente = new Paciente() { Genero = "M" };

            paciente.Genero.Should().BeOneOf(conditions);
        }

        [Test]
        public void ShouldReturnInvalidGenero()
        {
            static void InvalidGenero()
            {
                List<string> conditions = new List<string>() { "M", "F" };

                var paciente = new Paciente() { Genero = "X" };

                paciente.Genero.Should().BeOneOf(conditions);
            }

            Assert.Throws(typeof(AssertionException), InvalidGenero);
        }

        [Test]
        public void ShouldReturnValidCorreo()
        {
            var paciente = new Paciente() { Correo = "u201817688@upc.edu.pe" };

            paciente.Genero.Should().MatchRegex("@").And.MatchRegex(".");
        }

        [Test]
        public void ShouldReturnInvalidCorreo()
        {
            void InvalidCorreo()
            {
                var paciente = new Paciente() { Correo = "thematrix.com" };

                paciente.Genero.Should().MatchRegex("@").And.MatchRegex(".");
            }

            Assert.Throws(typeof(AssertionException), InvalidCorreo);
        }
    }
}
