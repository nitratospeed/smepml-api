using Application.Core.Predicciones.Queries;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Core.Predicciones.Queries
{
    using static Testing;
    public class GetPrediccionTests
    {
        [Test]
        public async Task ShouldReturnPrediccion()
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

            //arrange
            var query = new GetPrediccionQuery
            {
                Edad = 26,
                Sexo = "M",
                Condiciones = condiciones,
                Sintomas = sintomas
            };

            //act
            var result = await SendAsync(query);

            //assert (lo q deberia cumplir)
            result.Should().NotBeNull();
        }
    }
}
