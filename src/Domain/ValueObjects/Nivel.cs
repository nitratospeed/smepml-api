using Domain.Common;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class Nivel : ValueObject
    {
        static Nivel()
        {
        }

        private Nivel()
        {
        }

        private Nivel(int numeroNivel)
        {
            NumeroNivel = numeroNivel;
        }

        public static Nivel From(int numeroNivel)
        {
            var nivel = new Nivel { NumeroNivel = numeroNivel };

            if (!niveles.IsDefined(typeof(niveles), numeroNivel))
            {
                throw new UnsupportedNivelException(numeroNivel);
            }

            return nivel;
        }

        public int NumeroNivel { get; set; }

        public static implicit operator int(Nivel nivel)
        {
            return nivel.NumeroNivel;
        }

        public static explicit operator Nivel(int numeroNivel)
        {
            return From(numeroNivel);
        }

        private enum niveles
        {
            Leve,
            Moderado,
            Fuerte
        }
    }
}
