using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Clases.Comparables.Tipos;
using TP.TP6.Interfaces;
using TP.TP6.Interfaces.Comparar;
using TP.TP6.Interfaces.Iterador;

namespace TP.TP6.Colecciones.Diccionario
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
