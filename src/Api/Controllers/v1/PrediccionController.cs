using Application.Core.Predicciones.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    public class PrediccionController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<List<string>>> Create(PrediccionCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
