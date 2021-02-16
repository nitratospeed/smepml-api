using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMEPMLBack.Infrastructure.Repositories
{
    public class EnfermedadRepository : IEnfermedadRepository
    {
        protected readonly AppDbContext _context;

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

        public Task<IEnumerable<Enfermedad>> Obtener()
        {
            throw new NotImplementedException();
        }

        public Task<Enfermedad> ObtenerPorId()
        {
            throw new NotImplementedException();
        }
    }
}
