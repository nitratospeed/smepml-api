﻿using Application.Core.Enfermedades.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class EnfermedadController : BaseApiController
    {
        [HttpGet("{name}")]
        public async Task<IActionResult> GetById(string name)
        {
            return Ok(await Mediator.Send(new GetEnfermedadByNameQuery { Nombre = name }));
        }
    }
}
