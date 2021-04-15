using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjExpendedora.Libreria.Entidades
{
    public class Expendedora
    {
        List<Lata> _latas;
        string _proveedor;
        int _capacidad;
        double _dinero;
        bool _encendida;
        int _capacidadRestante;

        public bool Encendida { get => _encendida;}

        public Expendedora(string proveedor, int capacidad)
        {
            this._latas = new List<Lata>();
            this._proveedor = proveedor;
            this._capacidad = capacidad;
            this._capacidadRestante = capacidad;
        }

        public string EncenderMaquina()
        {
            if (this._encendida==true)
            {
                return "La máquina ya se encuentra encendida\n";
            }
            else
            {
                this._encendida = true;
                return "La máquina ha sido encendida\n";
            }
        }

        public void AgregarLata(string codigo, double precio, double volumen, int cantidad, string nombre, string sabor)
        {
            Lata lata = new Lata(codigo, precio, volumen, cantidad, nombre, sabor);
            _latas.Add(lata);
            ModificarCapacidadRestante(cantidad);
        }

        public string ListarLatasDisponibles()
        {
            if (EstaVacia() == true)
            {
                return "La maquina está vacía";
            }
            else
            {
                string valor = "";
                foreach (Lata lata in _latas)
                {
                    if (lata.Cantidad != 0)
                    {
                        valor = valor + lata.DescripSimple() + "\n";
                    }
                }
                return valor;
            }
        }

        public string ListarSoloCodigo()
        {
            string valor = "";
            foreach (Lata lata in _latas)
            {
                valor = valor + lata.DescripSimple() + "\n";                
            }
            return valor;
        }

        public void ExtraerLata(string codigo, int cantidad, double dinero)
        {
            this.ModificarStockLata(codigo, -cantidad);
            this.SumarDinero(dinero);
        }

        public string GetBalance()
        {
            string descripción;
            descripción = "La máquina tiene $ " + _dinero + " La cantidad de latas en stock es " + (_capacidad - _capacidadRestante) + "\n";
            
            return descripción.ToString(); 
        }

        public string GetStock()
        {
            string valor = "";
            foreach (Lata lata in _latas)
            {
                if (lata.Cantidad != 0)
                {
                    valor = valor + lata.DescripCompleta() + "\n";
                }
            }
            return valor;
        }

        void SumarDinero(double dinero)
        {
            this._dinero = this._dinero + dinero;
        }

        public void ModificarStockLata(string codigo, int cantidad)
        {
            foreach (Lata lata in this._latas)
            {
                if (lata.Codigo == codigo)
                {
                    lata.Cantidad = lata.Cantidad + cantidad;
                    ModificarCapacidadRestante(cantidad);
                }
            }
        }

        void ModificarCapacidadRestante(int cantidad)
        {
            _capacidadRestante = _capacidadRestante - cantidad;
        }

        public Lata BuscarCodigoDevuelveLata(string codigo)
        {
            Lata valor = null;
            foreach (Lata lata in this._latas)
            {
                if (lata.Codigo == codigo)
                {
                    valor = lata;
                }
            }
            return valor;
        }

        public int GetCapacidadRestante()
        {
            return this._capacidadRestante;
        }

        public bool EstaVacia()
        {
            if(_capacidad-_capacidadRestante==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
