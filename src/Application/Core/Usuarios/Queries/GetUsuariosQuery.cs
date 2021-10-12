using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Enums;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Usuarios.Queries
{
    public class GetUsuariosQuery : IRequest<PaginatedList<UsuarioDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string Nombres { get; set; }
        public int? Perfil { get; set; }
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
            var perfil = new PerfilEnum();

            if (request.Perfil == 1){ perfil = PerfilEnum.Administrador; }
            if (request.Perfil == 2) { perfil = PerfilEnum.Medico; }

            var result = await context.Usuarios
                .Where(x=> (x.NombreCompleto.Contains(request.Nombres) || request.Nombres == null)
                && (x.Perfil == perfil || request.Perfil == null))
                .OrderByDescending(x => x.Id)
                .ProjectTo<UsuarioDto>(mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
