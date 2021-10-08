using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IMailKitService
    {
        Task<bool> SendEmail(string html, Diagnostico diagnostico, string correoDe, string contrasenaDe);
    }
}
