using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface IPreguntaRepository
    {
        Task<IEnumerable<Pregunta>> GetAll();
        Task<IEnumerable<Pregunta>> GetSearch(Expression<Func<Pregunta, bool>> filter);
    }
}
