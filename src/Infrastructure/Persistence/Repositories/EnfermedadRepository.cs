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
    public class EnfermedadRepository : IEnfermedadRepository
    {
        private readonly IAppDbContext _context;

        public EnfermedadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enfermedad>> GetAll()
        {
            return await _context.Enfermedades.Include(x => x.Examenes).ToListAsync();
        }

        public async Task<Enfermedad> GetFilter(Expression<Func<Enfermedad, bool>> filter)
        {
            return await _context.Enfermedades.AsNoTracking().FirstOrDefaultAsync(filter);
        }
    }
}
