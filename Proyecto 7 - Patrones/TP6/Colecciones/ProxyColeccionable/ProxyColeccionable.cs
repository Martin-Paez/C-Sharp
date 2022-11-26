using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Clases.Fabricas;
using TP.TP6.Interfaces;
using TP.TP6.Interfaces.Comparar;
using TP.TP6.Interfaces.Iterador;
using TP.TP6.Interfaces.Oberservar;

namespace TP.TP6.Colecciones.ProxyColeccionableNS
{
    public class ProxyColeccionable<T> : Coleccionable<T>, Observador<T>,
    Observable<AdapterIterador<T>,Iterador<T>> where T : Comparable<T>,Observable<Observador<T>>
    {
        private Coleccionable<T>? Col;
        private List<AdapterIterador<T>> itrs = new();
        private T? min;
        private T? max;
        private FabColeccionables<T>.TipoCol TipoCol;
        public ProxyColeccionable(FabColeccionables<T>.TipoCol? coleccion=null)
        {
            if (coleccion == null)
                TipoCol = FabColeccionables<T>.Seleccionar();
        }
        public void Agregar(T c)
        {
            if (Col == null)
            {
                Col = FabColeccionables<T>.Crear(TipoCol);
                Publicar(Col.crearItr());
            }
            Col.Agregar(c);
            c.Suscribir(this);
            min = default;
            max = default;
        }

        public bool Contiene(T c)
        {
            if (Col == null)
                return false;
            return Col.Contiene(c);
        }

        public Iterador<T> crearItr()
        {
            AdapterIterador<T> a;
            if (Col == null)
                a = new(new ListItr<T>(new List<T>()));
            else
                a = new(Col.crearItr());
            Suscribir(a);
            return a;
        }

        public void Publicar(Iterador<T> info)
        {
            foreach (AdapterIterador<T> a in itrs)
                a.RecibirNotificacion(this, info);
        }

        public void Suscribir(AdapterIterador<T> s)
        {
            itrs.Add(s);
        }
        
        public int Cuantos()
        {
            if (Col == null)
                return 0;
            return Col.Cuantos();
        }

        public void Ordenar(IComparer<T> cmp)
        {
            if (Col != null)
                Col.Ordenar(cmp);
        }

        /* Voy realizar un cambio en el enunciado., porque me parece conveniente.
         * Solo se calcula min y max cuando el usuario lo pide y si realmente la 
         * coleccion tuvo modificaciones (se memoriza el ultimo).
         */
        public T? Maximo()
        {
            if (max == null)
                if (Col == null)
                    return default;
                else
                    return max = Col!.Maximo();
            return max;
        }

        public T? Minimo()
        {
            if (min == null)
                if (Col == null)
                    return default;
                else
                    return min = Col!.Minimo();
            return min;
        }

        public void RecibirNotificacion()
        {
            min = default;
            max = default;
        }

    }
}
