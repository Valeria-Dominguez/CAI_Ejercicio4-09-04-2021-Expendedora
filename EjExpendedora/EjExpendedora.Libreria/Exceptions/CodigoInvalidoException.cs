using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjExpendedora.Libreria.Exceptions
{
    public class CodigoInvalidoException : Exception
    {
        public CodigoInvalidoException() : base ("Código inválido\n")
        {

        }
        public CodigoInvalidoException(string message) : base(message)
        {

        }
    }
}
