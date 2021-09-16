using Application.Common.Interfaces;
using Application.Common.Mappings;
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
    }

    public class GetSintomasQueryHandler : IRequestHandler<GetSintomasQuery, List<SintomaDto>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext context;

        public GetSintomasQueryHandler(IMapper mapper, IAppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<SintomaDto>> Handle(GetSintomasQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Sintomas
                .ProjectToListAsync<SintomaDto>(mapper.ConfigurationProvider);

            return result;
        }
    }
}
