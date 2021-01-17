using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces;
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
        private readonly ISintomaRepository _sintomaRepository;

        public SintomaController(ISintomaRepository sintomaRepository)
        {
            _sintomaRepository = sintomaRepository;
        }

        [HttpGet]
        public List<Sintoma> ObtenerSintomas()
        {
            var resultado = _sintomaRepository.ObtenerSintomas();
            return resultado;
        }
    }
}
