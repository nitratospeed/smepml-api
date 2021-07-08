using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IAppDbContext context;
        public PacienteRepository(IAppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Paciente>> GetAll()
        {
            return await context.Pacientes.ToListAsync();
        }

        public async Task<int> Add(Paciente paciente)
        {
            context.Pacientes.Add(paciente);
            await context.SaveChangesAsync();

            return paciente.Id;
        }
    }
}
