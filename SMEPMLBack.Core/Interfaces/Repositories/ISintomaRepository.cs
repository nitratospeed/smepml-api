using SMEPMLBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMEPMLBack.Core.Interfaces.Repositories
{
    public interface ISintomaRepository
    {
        void Agregar();
        void Actualizar();
        void Eliminar();
        Task<IEnumerable<Sintoma>> Obtener();
        Task<Sintoma> ObtenerPorId();
    }
}
