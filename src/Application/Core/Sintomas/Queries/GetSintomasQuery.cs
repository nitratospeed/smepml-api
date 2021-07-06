using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Sintomas.Queries
{
    public class GetSintomasQuery : IRequest<List<SintomaDto>>
    {
        public string Nombre { get; set; }
    }

    public class GetSintomasQueryHandler : IRequestHandler<GetSintomasQuery, List<SintomaDto>>
    {
        private readonly IMapper mapper;
        private readonly ISintomaRepository sintomaRepository;

        public GetSintomasQueryHandler(IMapper mapper, ISintomaRepository sintomaRepository)
        {
            this.mapper = mapper;
            this.sintomaRepository = sintomaRepository;
        }

        public async Task<List<SintomaDto>> Handle(GetSintomasQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Sintoma> result = new List<Sintoma>();

            if (request.Nombre is null)
            {
                result = await sintomaRepository.GetAll();
            }
            else
            {
                result = await sintomaRepository.GetSearch(x => x.Nombre.ToLower().Contains(request.Nombre.ToLower()));
            }

            return result.AsQueryable().ProjectTo<SintomaDto>(mapper.ConfigurationProvider).ToList();
        }
    }
}
