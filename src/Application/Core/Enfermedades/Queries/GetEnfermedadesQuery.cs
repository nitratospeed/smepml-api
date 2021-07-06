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

namespace Application.Core.Enfermedades.Queries
{
    public class GetEnfermedadesQuery : IRequest<IEnumerable<EnfermedadDto>>
    {
    }

    public class GetEnfermedadesQueryHandler : IRequestHandler<GetEnfermedadesQuery, IEnumerable<EnfermedadDto>>
    {
        private readonly IEnfermedadRepository repository;
        private readonly IMapper mapper;

        public GetEnfermedadesQueryHandler(IEnfermedadRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EnfermedadDto>> Handle(GetEnfermedadesQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();
            return result.AsQueryable().ProjectTo<EnfermedadDto>(mapper.ConfigurationProvider).ToList();
        }
    }
}
