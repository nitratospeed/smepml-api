using Application.Core.Sintomas.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class SintomaController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetSintomasQuery { }));
        }
    }
}
