﻿using Application.Core.Predicciones.Queries;
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
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPrediccionQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}