using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjExpendedora.Libreria.Entidades;
using EjExpendedora.Libreria.Validaciones;
using EjExpendedora.Libreria.Exceptions;


namespace EjExpendedora.Consola
{
    static class Program
    {
        static Expendedora unaExpendedora;
        public static void Main(string[] args)
        {
            unaExpendedora = new Expendedora("Un proveedor",3);
            MenuPcipal();

            void MenuPcipal()
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
                            Console.WriteLine(unaExpendedora.EncenderMaquina());
                            break;
                        case opListarDispon:
                            Console.WriteLine(unaExpendedora.ListarLatasDisponibles());
                            break;
                        case opInsertar:
                            try
                            {
                                IngresarLata(unaExpendedora);
                            }
                            catch (CapacidadInsuficienteException CapacidadInsuficienteExce)
                            {
                                Console.WriteLine(CapacidadInsuficienteExce.Message);
                            }
                            break;
                        case opExtraer:
                            try
                            {
                                ExtraerLata(unaExpendedora);
                            }
                            catch (CodigoInvalidoException CodigoInvalidoExce)
                            {
                                Console.WriteLine(CodigoInvalidoExce.Message);
                            }
                            catch (DineroInsuficienteException DineroInsuficienteExce)
                            {
                                Console.WriteLine(DineroInsuficienteExce.Message);
                            }
                            catch (SinStockException SinStockExce)
                            {
                                Console.WriteLine(SinStockExce.Message);
                            }
                            break;
                        case opBalancear:
                            ObtenerBalance(unaExpendedora);
                            break;
                        case opListarStock:
                            MostrarStock(unaExpendedora);
                            break;
                        case opSalir:
                            ;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opción válida\n");
                            break;
                    }
                }
                while (option != opSalir);
            }
        }

        static void IngresarLata(Expendedora expendedora)
        {
            if(expendedora.Encendida==false)
            {
                Console.WriteLine("Primero debe encender la máquina");
            }
            else
            {                
                //Invertí los flujos alternativos, me pareció mejor primero chequear capacidad, y luego continuar con el pedido de código.
                int capacidadRestanteExpendedora;
                capacidadRestanteExpendedora = expendedora.GetCapacidadRestante();

                if (capacidadRestanteExpendedora == 0)
                {
                    throw new CapacidadInsuficienteException("Capacidad insuficiente\n");
                }

                //Agrego primero validar si con la cantidad de latas a ingresar se supera la capacidad
                int cantidadLata;
                cantidadLata = (int)Validaciones.ValidarUint("Ingrese cantidad de latas\n");
                if (capacidadRestanteExpendedora - cantidadLata < 0)
                {
                    Console.WriteLine("La cantidad de latas a ingresar supera la capacidad máxima");
                }
                else
                {
                    string codigoLata;
                    codigoLata = Validaciones.ValidarStrNoVac("Ingrese código de lata\n");
                    Lata lataEncontrada;
                    lataEncontrada = expendedora.BuscarCodigoDevuelveLata(codigoLata);
                    if (lataEncontrada != null)
                    {
                        expendedora.ModificarStockLata(codigoLata, cantidadLata);
                        Console.WriteLine("Ingreso exitoso");
                    }
                    else
                    {
                        double precioLata;
                        double volumenLata;
                        string nombreLata;
                        string saborLata;
                        precioLata = Validaciones.ValidarDoubleMayorACero("Ingrese precio de la lata\n");
                        volumenLata = Validaciones.ValidarDoubleMayorACero("Ingrese volumen de la lata\n");
                        nombreLata = Validaciones.ValidarStrNoVac("Ingrese nombre de la lata\n");
                        saborLata = Validaciones.ValidarStrNoVac("Ingrese sabor de la lata\n");
                        expendedora.AgregarLata(codigoLata, precioLata, volumenLata, cantidadLata, nombreLata, saborLata);
                        Console.WriteLine("Ingreso exitoso");
                    }
                }
            }
        }

        static void ExtraerLata(Expendedora expendedora)
        {
            if (expendedora.Encendida == false)
            {
                Console.WriteLine("Primero debe encender la máquina");
            }
            else if (expendedora.EstaVacia()==true)
            {
                Console.WriteLine("La máquina está vacía");
            }
            else
            {
                //Acá solo había que listar el código de cada lata?
                Console.WriteLine(expendedora.ListarSoloCodigo());
                string codigoLata;
                codigoLata = Validaciones.ValidarStrNoVac("Ingrese código de lata\n");
                Lata lataEncontrada;
                lataEncontrada = expendedora.BuscarCodigoDevuelveLata(codigoLata);

                if (lataEncontrada==null)
                {
                    throw new CodigoInvalidoException("Código inválido\n");
                }

                int cantidadLata;
                cantidadLata = (int)Validaciones.ValidarUint("Ingrese cantidad de latas\n");
                if (lataEncontrada.Cantidad == 0)
                {
                    throw new SinStockException("No hay stock de esa lata\n");
                }

                if (lataEncontrada.Cantidad - cantidadLata < 0)
                {
                    throw new SinStockException("La cantidad de latas a extraer supera la cantidad disponible\n");
                }

                double dineroCliente;
                dineroCliente = Validaciones.ValidarDoubleMayorACero("Indique monto a ingresar en $\n");
                double totalAPagar = lataEncontrada.Precio * cantidadLata;
                if (dineroCliente < totalAPagar)
                {
                    throw new DineroInsuficienteException("Monto a ingresar insuficiente\n");
                }

                string valor = expendedora.ExtraerLata(codigoLata, cantidadLata, dineroCliente, totalAPagar);                
                Console.WriteLine(valor);
            }
        }

        static void ObtenerBalance(Expendedora expendedora)
        {
            if (expendedora.Encendida == false)
            {
                Console.WriteLine("Primero debe encender la máquina");
            }
            else
            {
                Console.WriteLine(unaExpendedora.GetBalance());
            }
        }

        static void MostrarStock(Expendedora expendedora)
        {
            if (expendedora.Encendida == false)
            {
                Console.WriteLine("Primero debe encender la máquina");
            }
            else if (expendedora.EstaVacia() == true)
            {
                Console.WriteLine("La máquina está vacía");
            }
            else
            {
                Console.WriteLine(expendedora.GetStock());
            }
        }
    }
}
