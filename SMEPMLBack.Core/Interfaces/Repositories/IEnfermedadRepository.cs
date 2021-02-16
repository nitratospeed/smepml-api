using SMEPMLBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMEPMLBack.Core.Interfaces.Repositories
{
    public interface IEnfermedadRepository
    {      
        void Agregar();
        void Actualizar();
        void Eliminar();
        Task<IEnumerable<Enfermedad>> Obtener();
        Task<Enfermedad> ObtenerPorId();
    }
}
