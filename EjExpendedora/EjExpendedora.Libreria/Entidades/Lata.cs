using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjExpendedora.Libreria.Entidades
{
    public class Lata
    {
        string _codigo;
        string _nombre;
        string _sabor;
        double _precio;
        double _volumen;
        int _cantidad;

        internal string Codigo { get => _codigo;}
        public int Cantidad { get => _cantidad; internal set => _cantidad = value; }
        public double Precio { get => _precio; }

        internal Lata(string codigo, double precio, double volumen, int cantidad, string nombre, string sabor)
        {
            this._codigo = codigo;
            this._precio = precio;
            this._volumen = volumen;
            this._cantidad = cantidad;
            this._nombre = nombre;
            this._sabor = sabor;
        }

        internal string DescripSimple()
        {
            string descripcion = this._codigo + ")\t" + this._nombre + "\t" + this._sabor + "\t[" + this._cantidad + "]";
            return descripcion.ToString();
        }

        internal string DescripSoloCodigo()
        {
            string descripcion = this._codigo;
            return descripcion.ToString();
        }

        internal string DescripCompleta()
        {
            string descripcion = string.Format("{0} - {1} $ {2} / $/L {3} - [{4}]",this._nombre, this._sabor, this._precio, this.GetPrecioPorLitro(),this._cantidad);
            return descripcion.ToString();
        }

        double GetPrecioPorLitro()
        {
            double pcioPorLt;
            pcioPorLt = this._precio / this._volumen * 1000;
            return pcioPorLt;
        }

    }
}
