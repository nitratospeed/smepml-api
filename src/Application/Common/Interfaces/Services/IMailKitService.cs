using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IMailKitService
    {
        Task<bool> SendEmail(Diagnostico diagnostico, string correoDe, string contrasenaDe);
    }
}
