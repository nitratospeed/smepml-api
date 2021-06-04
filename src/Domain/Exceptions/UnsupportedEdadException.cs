using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class UnsupportedEdadException : Exception
    {
        public UnsupportedEdadException(int numeroEdad)
            : base($"Edad \"{numeroEdad}\" no permitida.")
        {
        }
    }
}
