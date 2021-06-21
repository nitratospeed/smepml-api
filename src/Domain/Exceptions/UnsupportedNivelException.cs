using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class UnsupportedNivelException : Exception
    {
        public UnsupportedNivelException(int numeroNivel)
            : base($"Nivel \"{numeroNivel}\" no existe.")
        {
        }
    }
}
