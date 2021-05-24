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
        public string Nombre { get; set; }
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
            if (request.Nombre is null)
            {
                return await repository.GetAll();
            }
            else
            {
                return await repository.GetSearch(x => x.Nombre.ToLower().Contains(request.Nombre.ToLower()));
            }
        }
    }
}
