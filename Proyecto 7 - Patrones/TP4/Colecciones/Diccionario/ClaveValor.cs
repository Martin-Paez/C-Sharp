using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Clases;
using TP.TP4.Interfaces;
using TP.TP4.Interfaces.Comparar;
using TP.TP4.Interfaces.Iterador;
using TP.TP4.Clases.Utiles;

namespace TP.TP4.Colecciones.Diccionario
{
    public class ClaveValor<K, T> : Tupla<K, T>, Comparable<ClaveValor<K, T>> 
        where K : Comparable<K> where T : Comparable<T>
    {
        public ClaveValor(K k, T e) : base(k,e) { }

        public bool SosIgual(ClaveValor<K, T> c)
        {
            return Y.SosIgual(c.Y);
        }

        public bool SosMayor(ClaveValor<K, T> c)
        {
            return Y.SosMayor(c.Y);
        }

        public bool SosMenor(ClaveValor<K, T> c)
        {
            return Y.SosMenor(c.Y);
        }
        public override string ToString()
        {
            return "[ K = '" + X.ToString() + "', Elem = '" + Y.ToString() + "' ]";
        }
    }
}
