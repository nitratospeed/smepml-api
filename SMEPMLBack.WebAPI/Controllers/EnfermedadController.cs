using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces;
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
        private readonly IEnfermedadRepository _enfermedadRepository;

        public EnfermedadController(IEnfermedadRepository enfermedadRepository)
        {
            _enfermedadRepository = enfermedadRepository;
        }

        [HttpGet]
        public List<Enfermedad> ObtenerEnfermedades()
        {
            var resultado = _enfermedadRepository.ObtenerEnfermedades();
            return resultado;
        }
    }
}
