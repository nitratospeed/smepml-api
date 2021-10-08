using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IPdfService
    {
        byte[] GetPdf(string html);
    }
}
