using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces;
using SMEPMLBack.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEPMLBack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EnfermedadController : ControllerBase
    {
        private readonly IEnfermedadService _enfermedadService;

        public EnfermedadController(IEnfermedadService enfermedadService)
        {
            _enfermedadService = enfermedadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await _enfermedadService.Obtener();
            return Ok(resultado);
        }
    }
}
