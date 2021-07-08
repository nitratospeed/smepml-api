using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAll();
        Task<int> Add(Paciente paciente);
    }
}
