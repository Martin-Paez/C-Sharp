using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Clases;
using TP.TP6.Interfaces;
using TP.TP6.Interfaces.Comparar;
using TP.TP6.Interfaces.Iterador;

namespace TP.TP6.Colecciones.Diccionario
{
    public interface KeyGen<K> where K : Comparable<K>
    {
        K getK();
    }
}
