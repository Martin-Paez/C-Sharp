using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Clases;
using TP.TP5.Interfaces;
using TP.TP5.Interfaces.Comparar;
using TP.TP5.Interfaces.Iterador;

namespace TP.TP5.Colecciones.Diccionario
{
    public interface KeyGen<K> where K : Comparable<K>
    {
        K getK();
    }
}
