using Application.Core.Diagnosticos.Commands;
using Application.Core.Diagnosticos.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
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

        [HttpGet("pdf")]
        public async Task<IActionResult> PdfById(int id)
        {
            return File(await Mediator.Send(new PdfDiagnosticoByIdQuery { Id = id }), "application/octet-stream", $"reporte_000{id}.pdf");
        }

        [HttpGet("report")]
        public async Task<IActionResult> Report(int tipoReporte)
        {
            return Ok(await Mediator.Send(new ReportDiagnosticosQuery { TipoReporte = tipoReporte }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiagnosticoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("rating")]
        public async Task<IActionResult> Rating(RatingDiagnosticoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("predict")]
        public async Task<IActionResult> Predict(PredictDiagnosticoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("email/{id}")]
        public async Task<IActionResult> Email(int id)
        {
            return Ok(await Mediator.Send(new EmailDiagnosticoCommand { Id = id }));
        }
    }
}
