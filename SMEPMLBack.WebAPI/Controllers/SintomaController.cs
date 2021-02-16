using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces;
using SMEPMLBack.Core.Interfaces.Services;
using SMEPMLBack.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEPMLBack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SintomaController : ControllerBase
    {
        private readonly ISintomaService _sintomaService;

        public SintomaController(ISintomaService sintomaService)
        {
            _sintomaService = sintomaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await _sintomaService.Obtener();
            return Ok(resultado);
        }
    }
}
