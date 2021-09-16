using Application.Core.Sintomas.Queries;
using Microsoft.AspNetCore.Mvc;
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
