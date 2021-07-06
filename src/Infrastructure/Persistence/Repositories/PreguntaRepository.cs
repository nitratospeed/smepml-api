using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PreguntaRepository : IPreguntaRepository
    {
        private readonly IAppDbContext context;
        public PreguntaRepository(IAppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Pregunta>> GetAll()
        {
            return await context.Preguntas.ToListAsync();
        }

        public async Task<IEnumerable<Pregunta>> GetSearch(Expression<Func<Pregunta, bool>> filter)
        {
            return await context.Preguntas.AsNoTracking().Where(filter).ToListAsync();
        }
    }
}
