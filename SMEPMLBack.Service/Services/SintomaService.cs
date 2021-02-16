using SMEPMLBack.Core.Entities;
using SMEPMLBack.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMEPMLBack.Service.Services
{
    public class SintomaService : ISintomaService
    {
        private readonly ISintomaService _sintomaService;

        public SintomaService(ISintomaService sintomaService)
        {
            _sintomaService = sintomaService;
        }

        public async Task<IEnumerable<Sintoma>> Obtener()
        {
            return await _sintomaService.Obtener();
        }
    }
}
