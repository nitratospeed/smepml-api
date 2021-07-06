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
    public class OpcionRepository : IOpcionRepository
    {
        private readonly IAppDbContext context;
        public OpcionRepository(IAppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Opcion>> GetAll()
        {
            return await context.Opciones.ToListAsync();
        }

        public async Task<IEnumerable<Opcion>> GetSearch(Expression<Func<Opcion, bool>> filter)
        {
            return await context.Opciones.AsNoTracking().Where(filter).ToListAsync();
        }
    }
}
