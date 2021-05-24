using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface ISintomaRepository
    {
        Task<IEnumerable<Sintoma>> GetAll();
        Task<Sintoma> GetFilter(Expression<Func<Sintoma, bool>> filter);
        Task<List<Sintoma>> GetSearch(Expression<Func<Sintoma, bool>> filter);
    }
}
