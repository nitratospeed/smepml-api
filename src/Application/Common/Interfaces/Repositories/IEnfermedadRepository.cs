using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface IEnfermedadRepository
    {
        Task<IEnumerable<Enfermedad>> GetAll();
    }
}
