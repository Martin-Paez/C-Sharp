using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Clases.Comparables.Tipos;
using TP.TP4.Interfaces;
using TP.TP4.Interfaces.Comparar;
using TP.TP4.Interfaces.Iterador;

namespace TP.TP4.Colecciones.Diccionario
{
    public class SimpleKeyGen : KeyGen<Numero>
    {
        private int semilla = 0;
        public Numero getK()
        {
            return new Numero(++semilla);
        }
    }
}
