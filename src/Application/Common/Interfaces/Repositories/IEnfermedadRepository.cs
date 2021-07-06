using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface IEnfermedadRepository
    {
        Task<IEnumerable<Enfermedad>> GetAll();
        Task<Enfermedad> GetFilter(Expression<Func<Enfermedad, bool>> filter);
    }
}
