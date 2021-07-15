using Domain.Common;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class PacienteId : ValueObject
    {
        public static PacienteId From(int numeropacienteId)
        {
            var pacienteId = new PacienteId { NumeroPacienteId = numeropacienteId };

            if (pacienteId.NumeroPacienteId <= 0)
            {
                throw new UnsupportedPacienteIdException(numeropacienteId);
            }

            return pacienteId;
        }

        public int NumeroPacienteId { get; set; }

        public static implicit operator int(PacienteId pacienteId)
        {
            return pacienteId.NumeroPacienteId;
        }

        public static explicit operator PacienteId(int numeropacienteId)
        {
            return From(numeropacienteId);
        }
    }
}
