using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Clases;
using TP.TP2.Interfaces;
using TP.TP2.Interfaces.Comparar;
using TP.TP2.Interfaces.Iterador;

namespace TP.TP2.Colecciones.Diccionario
{
    public interface KeyGen<K> where K : Comparable<K>
    {
        K getK();
    }
}
