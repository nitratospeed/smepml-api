using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces.Repositories;
using SMEPMLBack.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMEPMLBack.Service.Services
{
    public class SintomaService : ISintomaService
    {
        private readonly ISintomaRepository _sintomaRepository;

        public SintomaService(ISintomaRepository sintomaRepository)
        {
            _sintomaRepository = sintomaRepository;
        }

        public async Task<IEnumerable<Sintoma>> Obtener()
        {
            return await _sintomaRepository.Obtener();
        }
    }
}
