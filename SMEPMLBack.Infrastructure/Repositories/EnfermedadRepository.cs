using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMEPMLBack.Infrastructure.Repositories
{
    public class EnfermedadRepository : IEnfermedadRepository
    {
        protected readonly AppDbContext _context;

        public EnfermedadRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Enfermedad> ObtenerEnfermedades()
        {
            var enfermedades = _context.Enfermedad.ToList();

            return enfermedades;
        }
    }
}
