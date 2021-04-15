using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjExpendedora.Libreria.Exceptions
{
    public class CodigoInvalidoException : Exception
    {
        public CodigoInvalidoException()
        {

        }
        public CodigoInvalidoException(string message) : base(message)
        {

        }
    }
}
