using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Clases;
using TP.TP7.Interfaces;
using TP.TP7.Interfaces.Comparar;
using TP.TP7.Interfaces.Iterador;

namespace TP.TP7.Colecciones.Diccionario
{
    public interface KeyGen<K> where K : Comparable<K>
    {
        K getK();
    }
}
