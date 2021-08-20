using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IMailKitService
    {
        Task<bool> SendEmail(string correo, string correoDe, string contrasenaDe);
    }
}
