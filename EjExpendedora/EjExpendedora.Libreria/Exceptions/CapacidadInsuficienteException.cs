using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjExpendedora.Libreria.Exceptions
{
    public class CapacidadInsuficienteException : Exception
    {
        public CapacidadInsuficienteException() : base ("Capacidad insuficiente\n")
        {

        }
        public CapacidadInsuficienteException(string message) : base(message)
        {

        }
    }
}
