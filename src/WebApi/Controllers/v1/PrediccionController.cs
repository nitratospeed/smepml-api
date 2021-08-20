using Application.Core.Predicciones.Commands;
using Application.Core.Predicciones.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class PrediccionController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPrediccionesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrediccionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail(SendEmailPrediccionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
