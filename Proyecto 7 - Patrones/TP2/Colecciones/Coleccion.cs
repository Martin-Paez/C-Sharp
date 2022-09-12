using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Colecciones.Iteradores;
using TP.TP2.Interfaces;
using TP.TP2.Interfaces.Comparar;
using TP.TP2.Interfaces.Iterador;

namespace TP.TP2.Colecciones
{
    public class Coleccion<T> : Coleccionable<T> where T : Comparable<T>
    {
        protected List<T> Elems = new List<T>();

        public virtual void Agregar(T c)
        {
            Elems.Add(c);
        }
        public bool Contiene(T patron)
        {   // Seria mas eficiente, por Strategy, que la coleccion tenga un Comparador
            foreach (T e in Elems)
                if (patron.SosIgual(e))
                    return true;
            return false;
        }
        public virtual Iterador<T> crearItr()
        {
            return new ListItr<T>(this.Elems);
        }
        public int Cuantos()
        {
            return Elems.Count;
        }
        // TODO - Es igual a Minimo()
        public T? Maximo()
        {
            if (Elems.Count < 1)
                return default(T);
            T? n = Elems[0];
            for (int i = 0; i < Elems.Count; i++)
            {
                if (n.SosMayor(Elems[i]))
                    n = Elems[i];
            }
            return n;
        }
        public T? Minimo()
        {
            if (Elems.Count < 1)
                return default(T);
            T? n = Elems[0];
            for (int i = 0; i < Elems.Count; i++)
            {
                if (n.SosMenor(Elems[i]))
                    n = Elems[i];
            }
            return n;
        }
    }
}
