using SMEPMLBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMEPMLBack.Core.Interfaces.Services
{
    public interface IEnfermedadService
    {
        Task<IEnumerable<Enfermedad>> Obtener();
    }
}
