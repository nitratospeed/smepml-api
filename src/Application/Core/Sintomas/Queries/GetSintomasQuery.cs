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
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetSintomasQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<SintomaDto>> Handle(GetSintomasQuery request, CancellationToken cancellationToken)
        {
            if (request.Nombre is null)
            {
                return await context.Sintomas.Include(x=>x.Preguntas).ThenInclude(x=>x.Opciones).ProjectTo<SintomaDto>(mapper.ConfigurationProvider).ToListAsync();
            }
            else
            {
                return await context.Sintomas.Include(x => x.Preguntas).ThenInclude(x => x.Opciones).Where(x => x.Nombre.ToLower().Contains(request.Nombre.ToLower())).ProjectTo<SintomaDto>(mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}
