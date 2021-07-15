using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class UnsupportedPacienteIdException : Exception
    {
        public UnsupportedPacienteIdException(int numeroDiagnosticoId)
            : base($"El Paciente de Id \"{numeroDiagnosticoId}\" no existe.")
        {
        }
    }
}
