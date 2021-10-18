using Application.Core.Incidencias.Commands;
using Application.Core.Incidencias.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class IncidenciaController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetIncidenciasQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetIncidenciaByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(string titulo, string descripcion, string urgencia, string estado, IFormFile adjuntoUrl)
        {
            return Ok(await Mediator.Send(new CreateIncidenciaCommand { Titulo = titulo, Descripcion = descripcion, Urgencia = urgencia, Estado = estado, AdjuntoUrl = adjuntoUrl }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateIncidenciaCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteIncidenciaCommand { Id = id }));
        }
    }
}
