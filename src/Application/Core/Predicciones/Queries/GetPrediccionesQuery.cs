using Application.Common.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Predicciones.Queries
{
    public class GetPrediccionesQuery : IRequest<IEnumerable<GetPrediccionesDto>>
    {
    }

    public class GetPrediccionesQueryHandler : IRequestHandler<GetPrediccionesQuery, IEnumerable<GetPrediccionesDto>>
    {
        private readonly IDiagnosticoRepository diagnosticoRepository;

        public GetPrediccionesQueryHandler(IDiagnosticoRepository diagnosticoRepository)
        {
            this.diagnosticoRepository = diagnosticoRepository;
        }

        public async Task<IEnumerable<GetPrediccionesDto>> Handle(GetPrediccionesQuery request, CancellationToken cancellationToken)
        {
            var diagnosticos = await diagnosticoRepository.GetAll();

            var listaDto = new List<GetPrediccionesDto>();

            foreach (var item in diagnosticos.ToList().OrderByDescending(x=>x.Id))
            {
                var dto = new GetPrediccionesDto
                {
                    Id = item.Id,
                    Nombres = item.Paciente.NombresApellidos,
                    Edad = item.Paciente.Edad,
                    Genero = item.Paciente.Genero,
                    Sintomas = item.Sintomas,
                    ResultadoMasPreciso = item.ResultadoMasPreciso ?? ""
                };
                listaDto.Add(dto);
            }

            return listaDto;
        }
    }
}
