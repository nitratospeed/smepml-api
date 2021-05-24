using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Actualizar()
        {
            throw new NotImplementedException();
        }

        public void Agregar()
        {
            throw new NotImplementedException();
        }

        public void Eliminar()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sintoma>> Obtener()
        {
            return await _context.Sintomas.ToListAsync();
        }

        public Task<Sintoma> ObtenerPorId()
        {
            throw new NotImplementedException();
        }
    }
}
