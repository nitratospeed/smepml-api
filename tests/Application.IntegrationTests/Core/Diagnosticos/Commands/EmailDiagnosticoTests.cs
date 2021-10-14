using Application.Core.Diagnosticos.Commands;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Core.Diagnosticos.Commands
{
    using static Testing;
    public class EmailDiagnosticoTests
    {
        [Test]
        public async Task ShouldEmailDiagnostico()
        {
            //arrange
            var command = new EmailDiagnosticoCommand
            {
                Id = 28
            };

            //act
            var result = await SendAsync(command);

            //assert (lo q deberia cumplir)
            result.Should().Be(true);
        }
    }
}
