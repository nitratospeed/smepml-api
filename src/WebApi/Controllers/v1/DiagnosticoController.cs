using Application.Core.Diagnosticos.Commands;
using Application.Core.Diagnosticos.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class DiagnosticoController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetDiagnosticosQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetDiagnosticoByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiagnosticoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("predict")]
        public async Task<IActionResult> Predict(PredictDiagnosticoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("email")]
        public async Task<IActionResult> Email(int id)
        {
            return Ok(await Mediator.Send(new EmailDiagnosticoCommand {  Id = id }));
        }
    }
}
