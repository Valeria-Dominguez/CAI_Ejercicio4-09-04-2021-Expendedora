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
        public static uint ValidarUint (string mensaje)
        {
            uint valor;
            do
            {
                Console.WriteLine(mensaje);
                if(!uint.TryParse(Console.ReadLine(), out valor))
                {
                    valor = 429496795;
                }
                if (valor== 429496795)
                {
                    Console.WriteLine("Debe ingresar un valor entero positivo");
                }
            }
            while (valor == 0);
            return valor;
        }
        public static int ValidarInt(string mensaje)
        {
            int valor;
            do
            {
                Console.WriteLine(mensaje);
                if (!int.TryParse(Console.ReadLine(), out valor))
                {
                    valor = 2147483647;
                }
                if (valor == 2147483647)
                {
                    Console.WriteLine("Debe ingresar un valor entero positivo");
                }
            }
            while (valor == 0);
            return valor;
        }
        public static double ValidarDoubleMayorACero(string mensaje)
        {
            double valor;
            do
            {
                Console.WriteLine(mensaje);
                if (!double.TryParse(Console.ReadLine(), out valor))
                {
                    valor = 0;
                }
                if (valor == 0)
                {
                    Console.WriteLine("Debe ingresar un valor positivo");
                }
            }
            while (valor == 0);
            return valor;
        }
    }
}
