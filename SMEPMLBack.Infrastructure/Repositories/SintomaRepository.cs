using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMEPMLBack.Infrastructure.Repositories
{
    public class SintomaRepository : ISintomaRepository
    {
        protected readonly AppDbContext _context;

        public SintomaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Sintoma> ObtenerSintomas()
        {
            var sintomas = _context.Sintoma.ToList();

            return sintomas;
        }
    }
}
