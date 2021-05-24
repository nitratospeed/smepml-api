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
    public class GetSintomasQuery : IRequest<IEnumerable<Sintoma>>
    {
    }

    public class GetSintomasQueryHandler : IRequestHandler<GetSintomasQuery, IEnumerable<Sintoma>>
    {
        private readonly ISintomaRepository repository;
        private readonly IMapper mapper;

        public GetSintomasQueryHandler(ISintomaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Sintoma>> Handle(GetSintomasQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.Obtener();

            return result;
        }
    }
}
