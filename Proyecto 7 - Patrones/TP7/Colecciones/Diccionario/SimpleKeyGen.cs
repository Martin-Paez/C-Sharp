using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Clases.Comparables.Tipos;
using TP.TP7.Interfaces;
using TP.TP7.Interfaces.Comparar;
using TP.TP7.Interfaces.Iterador;

namespace TP.TP7.Colecciones.Diccionario
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
