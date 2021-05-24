using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
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
