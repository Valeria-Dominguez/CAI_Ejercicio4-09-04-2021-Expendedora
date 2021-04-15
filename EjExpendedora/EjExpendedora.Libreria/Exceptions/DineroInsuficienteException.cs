using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjExpendedora.Libreria.Exceptions
{
    public class DineroInsuficienteException : Exception
    {
        public DineroInsuficienteException()
        {

        }
        public DineroInsuficienteException(string message) : base(message)
        {

        }
    }
}
