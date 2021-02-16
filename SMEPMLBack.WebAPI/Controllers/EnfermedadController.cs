using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces;
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
    public class EnfermedadController : ControllerBase
    {
        private readonly IEnfermedadService _enfermedadService;

        public EnfermedadController(IEnfermedadService enfermedadService)
        {
            _enfermedadService = enfermedadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var result = await _enfermedadService.Obtener();

            var pageFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var totalResult = result.Count();

            var totalPages = ((double)totalResult / (double)pageFilter.PageSize);

            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var pagedData = result
                .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                .Take(pageFilter.PageSize);

            return Ok(new PagedResponse<IEnumerable<Enfermedad>>(pagedData, pageFilter.PageNumber, pageFilter.PageSize, roundedTotalPages, totalResult));
        }
    }
}
