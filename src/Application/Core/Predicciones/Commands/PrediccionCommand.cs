﻿using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Predicciones.Commands
{
    public class PrediccionCommand : IRequest<PrediccionDto>
    {
        public string NombresApellidos { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public List<string> Condiciones { get; set; }
        public List<string> Preguntas { get; set; }
        public List<string> Sintomas { get; set; }
    }

    public class PrediccionCommandHandler : IRequestHandler<PrediccionCommand, PrediccionDto>
    {
        private readonly IAzureMLService service;
        private readonly IDiagnosticoRepository diagnosticoRepository;
        private readonly IPacienteRepository pacienteRepository;
        private readonly IEnfermedadRepository enfermedadRepository;

        public PrediccionCommandHandler(
            IAzureMLService service,
            IPacienteRepository pacienteRepository,
            IDiagnosticoRepository diagnosticoRepository,
            IEnfermedadRepository enfermedadRepository)
        {
            this.service = service;
            this.diagnosticoRepository = diagnosticoRepository;
            this.pacienteRepository = pacienteRepository;
            this.enfermedadRepository = enfermedadRepository;
        }

        public async Task<PrediccionDto> Handle(PrediccionCommand request, CancellationToken cancellationToken)
        {
            var paciente = new Paciente
            {
                NombresApellidos = request.NombresApellidos,
                Edad = request.Edad,
                Genero = request.Genero
            };

            await pacienteRepository.Add(paciente);


            var diagnostico = new Diagnostico
            {
                PacienteId = paciente.Id,
                Condiciones = string.Join(" ", request.Condiciones.ToArray()),
                Preguntas = string.Join(" ", request.Preguntas.ToArray()),
                Sintomas = string.Join(" ", request.Sintomas.ToArray())
            };

            await diagnosticoRepository.Add(diagnostico);

            var result = await service.GetPrediction(request.Genero, request.Edad, request.Condiciones, request.Sintomas);

            var recomend = await enfermedadRepository.GetFilter(x => x.Nombre == result.EnfermedadMasPrecisa);

            var prediccionDto = new PrediccionDto
            {
                Enfermedades = result.Resultados,
                Recomendacion = recomend.Recomendacion
            };

            return prediccionDto;
        }
    }
}