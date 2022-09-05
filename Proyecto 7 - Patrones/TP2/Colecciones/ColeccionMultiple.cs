using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces;

namespace TP.TP2.Colecciones
{
    public class ColeccionMultiple<T> : Coleccionable<T> where T : Comparable<T>
    {
        Pila<T> p;
        Cola<T> c;

        public ColeccionMultiple(Pila<T> p, Cola<T> c)
        {
            this.p = p;
            this.c = c;
        }

        public void Agregar(T c)
        {
            throw new NotImplementedException();
        }

        public bool Contiene(Comparable<T> n)
        {
            return p.Contiene(n) || c.Contiene(n);
        }

        public int Cuantos()
        {
            return p.Cuantos() + c.Cuantos();
        }

        public T? Maximo()
        {
            T? a = p.Maximo();
            T? b = c.Maximo();
            if (a == null)
                return b;
            else if (b == null)
                return a;

            if (a.SosMayor(b))
                return b;
            return a;
        }

        public T? Minimo()
        {
            T? a = p.Minimo();
            T? b = c.Minimo();
            if (a == null)
                return b;
            else if (b == null)
                return a;

            if (a.SosMenor(b))
                return b;
            return a;
        }

    }

}
