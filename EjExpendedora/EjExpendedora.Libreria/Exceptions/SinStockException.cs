using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjExpendedora.Libreria.Exceptions
{
    public class SinStockException: Exception
    {
        public SinStockException()
        {

        }
        public SinStockException(string message) : base(message)
        {

        }
    }
}
