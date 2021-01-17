using SMEPMLBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMEPMLBack.Core.Interfaces
{
    public interface ISintomaRepository
    {
        List<Sintoma> ObtenerSintomas();
    }
}
