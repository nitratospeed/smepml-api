using Application.Core.Diagnosticos.Commands;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Core.Diagnosticos.Commands
{
    using static Testing;
    public class CreateDiagnosticoTests
    {
        [Test]
        public async Task ShouldCreateDiagnostico()
        {
            var sintomas = new string[]
            {
                "Distension",
                "Dolor de estomago",
                "Nauseas"
            };

            var condiciones = new string[]
            {
                "Diabetes",
                "Hipertension"
            };

            var preguntas = new string[]
            {
                "¿Cuál es el nivel de su dolor?",
                "¿Cuántos días tiene las náuseas?"
            };

            var resultados = new string[]
            {
                "Gastritis: 57%",
                "Colitis: 47%"
            };

            //arrange
            var command = new CreateDiagnosticoCommand
            {
                PacienteId = 1,
                Condiciones = string.Join(", ", condiciones),
                Sintomas = string.Join(", ", sintomas),
                Preguntas = string.Join(", ", preguntas),
                Resultados = string.Join(", ", resultados),
                ResultadoMasPreciso = "Gastritis"
            };

            //act
            var result = await SendAsync(command);

            //assert (lo q deberia cumplir)
            result.Should().NotBe(null);
        }
    }
}
