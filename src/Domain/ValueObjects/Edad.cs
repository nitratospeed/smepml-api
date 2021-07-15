using Domain.Common;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Edad : ValueObject
    {
        public static Edad From(int numeroEdad)
        {
            var edad = new Edad { NumeroEdad = numeroEdad };

            if ((edad.NumeroEdad <= 18) || (edad.NumeroEdad >= 75))
            {
                throw new UnsupportedEdadException(numeroEdad);
            }

            return edad;
        }

        public int NumeroEdad { get; set; }

        public static implicit operator int(Edad edad)
        {
            return edad.NumeroEdad;
        }

        public static explicit operator Edad(int numeroEdad)
        {
            return From(numeroEdad);
        }
    }
}
