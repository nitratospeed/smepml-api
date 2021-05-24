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
    public class EnfermedadRepository : IEnfermedadRepository
    {
        private readonly IAppDbContext _context;

        public EnfermedadRepository(AppDbContext context)
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

        public async Task<IEnumerable<Enfermedad>> Obtener()
        {
            return await _context.Enfermedades.ToListAsync();
        }

        public Task<Enfermedad> ObtenerPorId()
        {
            throw new NotImplementedException();
        }
    }
}
