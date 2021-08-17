using Application.Core.Preguntas.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class PreguntaController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPreguntasQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
