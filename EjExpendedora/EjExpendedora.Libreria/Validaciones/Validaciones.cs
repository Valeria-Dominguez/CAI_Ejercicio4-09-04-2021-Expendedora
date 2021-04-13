using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjExpendedora.Libreria.Validaciones
{
    public class Validaciones
    {
        public static string ValidarStrNoVac(string mensaje)
        {
            string valor;
            do
            {
                Console.WriteLine(mensaje);
                valor = Console.ReadLine().ToUpper();
                if (valor == "")
                {
                    Console.WriteLine("El campo no puede estar vacío\n");
                }
            }
            while (valor == "");
            return valor;
        }
    }
}
