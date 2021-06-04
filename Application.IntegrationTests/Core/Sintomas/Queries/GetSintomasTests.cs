using Application.Core.Sintomas.Queries;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Core.Sintomas.Queries
{
    using static Testing;
    public class GetSintomasTests
    {
        [Test]
        public async Task ShouldReturnList()
        {
            //arrange
            var query = new GetSintomasQuery();

            //act
            var result = await SendAsync(query);

            //assert (lo q deberia cumplir)
            result.Should().NotBeNull();
        }
    }
}
