using Application.Core.Sintomas.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class SintomaController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSintomasQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
