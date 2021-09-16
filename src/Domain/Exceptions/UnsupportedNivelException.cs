using System;

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
