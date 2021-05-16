using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMEPMLBack.Core.Interfaces.Services;
using SMEPMLBack.Service.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEPMLBack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PrediccionController : ControllerBase
    {
        private readonly IModelService _modelService;

        public PrediccionController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBySintomas(string Sintoma1, string Sintoma2, string Sintoma3)
        {
            var resultado = await _modelService.ObtenerPrediccion(Sintoma1, Sintoma2, Sintoma3);
            return Ok(new Response<string>(resultado));
        }
    }
}
