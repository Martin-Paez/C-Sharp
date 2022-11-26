using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Interfaces;
using TP.TP7.Interfaces.Comparar;
using TP.TP7.Interfaces.Iterador;
using TP.TP7.Colecciones.Iteradores;

namespace TP.TP7.Colecciones
{
    public class ColeccionMultiple<T> : Coleccionable<T> where T : Comparable<T>
    {
        Coleccionable<T> p;
        Coleccionable<T> c;
        public ColeccionMultiple(Coleccionable<T> p, Coleccionable<T> c)
        {
            this.p = p;
            this.c = c;
        }
        public void Agregar(T c)
        {
            throw new NotImplementedException();
        }
        public bool Contiene(T n)
        {
            return p.Contiene(n) || c.Contiene(n);
        }
        public Iterador<T> crearItr()
        {
            List < Iterador < T >> itrs = new();
            itrs.Add(p.crearItr());
            itrs.Add(c.crearItr());
            return new ItrColMulti<T>(itrs);
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

        public void Ordenar(IComparer<T> cmp)
        {
            throw new NotImplementedException();
        }
    }
}
