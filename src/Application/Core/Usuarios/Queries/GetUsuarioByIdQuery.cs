using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Usuarios.Queries
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioDto>
    {
        public int Id { get; set; }
    }

    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioDto>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public GetUsuarioByIdQueryHandler(IMapper mapper, IAppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<UsuarioDto> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Usuarios
                .Where(x => x.Id == request.Id)
                .ProjectTo<UsuarioDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
