using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjExpendedora.Libreria.Entidades
{
    class Lata
    {
        string _codigo;
        string _nombre;
        string _sabor;
        double _precio;
        double _volumen;
        int _cantidad;

        double GetPrecioPorLitro()
        {
            double pcioPorLt;
            pcioPorLt = _precio / _volumen * 1000;
            return pcioPorLt;
        }
    }
}
