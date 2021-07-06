using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface IOpcionRepository
    {
        Task<IEnumerable<Opcion>> GetAll();
        Task<IEnumerable<Opcion>> GetSearch(Expression<Func<Opcion, bool>> filter);
    }
}
