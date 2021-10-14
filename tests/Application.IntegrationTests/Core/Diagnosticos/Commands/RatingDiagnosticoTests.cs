using Application.Core.Diagnosticos.Commands;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Core.Diagnosticos.Commands
{
    using static Testing;
    public class RatingDiagnosticoTests
    {
        [Test]
        public async Task ShouldRatingDiagnostico()
        {
            //arrange
            var command = new RatingDiagnosticoCommand
            {
                Id = 28,
                Calificacion = 5
            };

            //act
            var result = await SendAsync(command);

            //assert (lo q deberia cumplir)
            result.Should().Be(true);
        }
    }
}
