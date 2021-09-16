using Application.Core.Enfermedades.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class EnfermedadController : BaseApiController
    {
        [HttpGet("{nombre}")]
        public async Task<IActionResult> GetByNombre(string nombre)
        {
            return Ok(await Mediator.Send(new GetEnfermedadByNombreQuery { Nombre = nombre }));
        }
    }
}
