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

        void AgregarLata(Lata lat)
        {
            ;
        }
        Lata ExtraerLata(string str, double dbl)
        {
            Lata lat = new Lata();
            return lat;
        }
        string GetBalance()
        {
            double bce;
            bce = 0;
            return bce.ToString();
        }
        int GetCapacidadRestante()
        {
            int capRest;
            capRest = 0;
            return capRest;
        }
        void EncenderMaquina()
        {
            _encendida = true;
        }
        bool EstaVacia()
        {
            bool vacia;
            vacia = true;
            return vacia;
        }
    }
}
