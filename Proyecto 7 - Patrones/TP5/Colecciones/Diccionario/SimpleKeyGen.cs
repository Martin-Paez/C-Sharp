using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Clases.Comparables.Tipos;
using TP.TP5.Interfaces;
using TP.TP5.Interfaces.Comparar;
using TP.TP5.Interfaces.Iterador;

namespace TP.TP5.Colecciones.Diccionario
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
