using Application.Core.Predicciones.Commands;
using Application.Core.Predicciones.Queries;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Core.Predicciones.Commands
{
    using static Testing;
    public class CreatePrediccionTests
    {
        [Test]
        public async Task ShouldCreatePrediccion()
        {
            var sintomas = new List<string>
            {
                "Distension",
                "Dolor de estomago",
                "Nauseas"
            };

            var condiciones = new List<string>
            {
                "Diabetes",
                "Hipertension"
            };

            var preguntas = new List<string>
            {
                "¿Cuál es el nivel de su dolor?",
                "¿Cuántos días tiene las náuseas?"
            };

            //arrange
            var command = new PrediccionCommand
            {
                Edad = 26,
                Genero = "M",
                Condiciones = condiciones,
                Preguntas = preguntas,
                Sintomas = sintomas
            };

            //act
            var result = await SendAsync(command);

            //assert (lo q deberia cumplir)
            result.Should().NotBeNull();
        }
    }
}
