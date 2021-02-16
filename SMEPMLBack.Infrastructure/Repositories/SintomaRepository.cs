using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMEPMLBack.Infrastructure.Repositories
{
    public class SintomaRepository : ISintomaRepository
    {
        protected readonly AppDbContext _context;

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

        public Task<IEnumerable<Sintoma>> Obtener()
        {
            throw new NotImplementedException();
        }

        public Task<Sintoma> ObtenerPorId()
        {
            throw new NotImplementedException();
        }
    }
}
