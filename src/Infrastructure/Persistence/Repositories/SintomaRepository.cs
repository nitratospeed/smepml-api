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
    public class SintomaRepository : ISintomaRepository
    {
        private readonly IAppDbContext _context;

        public SintomaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sintoma>> GetAll()
        {
            return await _context.Sintomas.Include(x => x.Preguntas).ThenInclude(x => x.Opciones).ToListAsync();
        }

        public async Task<Sintoma> GetFilter(Expression<Func<Sintoma, bool>> filter)
        {
            return await _context.Sintomas.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<Sintoma>> GetSearch(Expression<Func<Sintoma, bool>> filter)
        {
            return await _context.Sintomas.AsNoTracking().Include(x => x.Preguntas).ThenInclude(x => x.Opciones).Where(filter).ToListAsync();
        }
    }
}
