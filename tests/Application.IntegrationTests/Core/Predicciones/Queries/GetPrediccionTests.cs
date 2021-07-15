using Application.Core.Predicciones.Commands;
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
            //arrange
            var query = new GetPrediccionesQuery
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
