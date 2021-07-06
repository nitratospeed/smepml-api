using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private readonly IAppDbContext context;
        public DiagnosticoRepository(IAppDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(Diagnostico diagnostico)
        {
            context.Diagnosticos.Add(diagnostico);
            await context.SaveChangesAsync();

            return diagnostico.Id;
        }
    }
}
