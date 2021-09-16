using Application.Core.Pacientes.Commands;
using Application.Core.Pacientes.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class PacienteController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPacientesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPacienteByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePacienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePacienteCommand command)
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
            return Ok(await Mediator.Send(new DeletePacienteCommand { Id = id }));
        }
    }
}
