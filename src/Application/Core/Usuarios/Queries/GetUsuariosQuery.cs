﻿using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Usuarios.Queries
{
    public class GetUsuariosQuery : IRequest<PaginatedList<UsuarioDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class GetUsuariosQueryHandler : IRequestHandler<GetUsuariosQuery, PaginatedList<UsuarioDto>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetUsuariosQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PaginatedList<UsuarioDto>> Handle(GetUsuariosQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Usuarios
                .OrderByDescending(x => x.Id)
                .ProjectTo<UsuarioDto>(mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}