using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces;

namespace TP.TP2.Colecciones
{
    public class Coleccion<T> : Coleccionable<T> where T : Comparable<T>
    {
        private List<T> elementos = new List<T>();

        // TODO, ¿¿ Esta bien usar T como parametro y ListComparable<T> , para 
        //      asegurarme de que solo guarden T y que ademas T sea Comparable ??
        // TODO, porque me obliga a chequear por null, si no tiene '?' el parametro
        // ¿ Generics no soporta '?' ?
        public void Agregar(T c)
        {
            if (c == null)
                return;
            elementos.Add(c!);
        }

        public bool Contiene(Comparable<T> c)
        {
            foreach (T e in elementos)
                if (c.SosIgual(e))
                    return true;
            return false;
        }

        public int Cuantos()
        {
            return elementos.Count;
        }

        public T? Maximo()
        {
            if (elementos.Count < 1)
                return default(T);
            T? n = elementos[0];
            for (int i = 0; i < elementos.Count; i++)
            {
                if (n.SosMayor(elementos[i]))
                    n = elementos[i];
            }
            return n;
        }

        public T? Minimo()
        {
            if (elementos.Count < 1)
                return default(T);
            T? n = elementos[0];
            for (int i = 0; i < elementos.Count; i++)
            {
                if (n.SosMenor(elementos[i]))
                    n = elementos[i];
            }
            return n;
        }
    }
}
