using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjExpendedora.Libreria.Entidades;
using EjExpendedora.Libreria.Validaciones;


namespace EjExpendedora.Consola
{
    static class Program
    {
        static void Main(string[] args)
        {
            string option = "";
            const string opEncender = "1";
            const string opListarDispon = "2";
            const string opInsertar = "3";
            const string opExtraer = "4";
            const string opBalancear = "5";
            const string opListarStock = "6";
            const string opSalir = "7";

            do
            {
                option = Validaciones.ValidarStrNoVac("Ingrese una opción\n" 
                    + opEncender + ". Encender máquina\n"
                    + opListarDispon + ". Listar latas disponibles\n" 
                    + opInsertar + ". Insertar lata\n" 
                    + opExtraer + ". Extraer lata\n" 
                    + opBalancear + ". Conocer balance\n" 
                    + opListarStock + ". Listar stock\n" 
                    + opSalir + ". Salir \n"
                    );
                switch (option)
                {
                    case opEncender:
                        ;
                        break;
                    case opListarDispon:
                        ;
                        break;
                    case opInsertar:
                        ;
                        break;
                    case opExtraer:
                        ;
                        break;
                    case opBalancear:
                        ;
                        break;
                    case opListarStock:
                        ;
                        break;
                    case opSalir:
                        ;
                        break;
                    default:
                        Console.WriteLine("Debe ingresar una opción válida");
                        break;
                }                    
            }
            while (option != opSalir);
        }
        static void IngresarLata(Expendedora expe)
        {
            
        }
        static void ExtraerLata(Expendedora expe)
        {
            
        }
        static void ObtenerBalance(Expendedora expe)
        {
            
        }
        static void MostrarStock(Expendedora expe)
        {
            
        }
    }
}
