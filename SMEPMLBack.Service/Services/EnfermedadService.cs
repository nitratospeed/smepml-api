using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces.Repositories;
using SMEPMLBack.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMEPMLBack.Service.Services
{
    public class EnfermedadService : IEnfermedadService
    {
        private readonly IEnfermedadRepository _enfermedadRepository;

        public EnfermedadService(IEnfermedadRepository enfermedadRepository)
        {
            _enfermedadRepository = enfermedadRepository;
        }

        public async Task<IEnumerable<Enfermedad>> Obtener()
        {
            return await _enfermedadRepository.Obtener();
        }
    }
}
