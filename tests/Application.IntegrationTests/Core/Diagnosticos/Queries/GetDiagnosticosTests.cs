using Application.Core.Diagnosticos.Queries;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Core.Diagnosticos.Queries
{
    using static Testing;
    public class GetDiagnosticosTests
    {
        [Test]
        public async Task ShouldReturnDiagnostico()
        {
            //arrange
            var query = new GetDiagnosticosQuery
            {
                PageNumber = 1,
                PageSize = 5
            };

            //act
            var result = await SendAsync(query);

            //assert (lo q deberia cumplir)
            result.Should().NotBeNull();
        }
    }
}
