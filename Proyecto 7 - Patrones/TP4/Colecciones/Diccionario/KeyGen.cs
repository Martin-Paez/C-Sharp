using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Clases;
using TP.TP4.Interfaces;
using TP.TP4.Interfaces.Comparar;
using TP.TP4.Interfaces.Iterador;

namespace TP.TP4.Colecciones.Diccionario
{
    public interface KeyGen<K> where K : Comparable<K>
    {
        K getK();
    }
}
