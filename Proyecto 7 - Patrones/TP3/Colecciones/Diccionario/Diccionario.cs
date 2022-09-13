using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Clases;
using TP.TP3.Interfaces;
using TP.TP3.Interfaces.Comparar;
using TP.TP3.Interfaces.Iterador;
using TP.TP3.Colecciones.Iteradores;

namespace TP.TP3.Colecciones.Diccionario
{
    public class Diccionario<K, T> : Coleccion<ClaveValor<K, T>>, Coleccionable<T> where K : Comparable<K> where T : Comparable<T>
    {
        public KeyGen<K>? keyGen { get; set; }

        public Diccionario() { }

        public Diccionario(KeyGen<K>? keyGen)
        {
            this.keyGen = keyGen;
        }

        public void Agregar(T e)
        {
            if (keyGen == null)
                throw new Exception("No se proveyo un generador de claves");
            Agregar(keyGen.getK(), e);
        }

        public override void Agregar(ClaveValor<K, T> c)
        {
            Agregar(c.X, c.Y);
        }

        public void Agregar(K k, T e)
        {
            ClaveValor<K, T>? tupla = GetTupla(k);
            if (tupla == null)
                base.Agregar(new ClaveValor<K, T>(k, e));
            else
                tupla.Y = e;
        }

        public T? ValorDe(K k)
        {
            ClaveValor<K, T>? tupla = GetTupla(k);
            if (tupla != null)
                return tupla.Y;
            return default; // T : Comparable<T> => default == null
        }

        public ClaveValor<K, T>? GetTupla(K k)
        {
            foreach (ClaveValor<K, T> c in Elems)
                if (c.X.SosIgual(k))
                    return c;
            return null;
        }

        T? Coleccionable<T>.Minimo()
        {
            ClaveValor<K, T>? c = Minimo();
            if (c != null)
                return c.Y;
            return default;
        }

        T? Coleccionable<T>.Maximo()
        {
            ClaveValor<K, T>? c = Maximo();
            if (c != null)
                return c.Y;
            return default;
        }

        public bool Contiene(T patron)
        {
            return base.Contiene(new ClaveValor<K,T>(keyGen!.getK(), patron));
        }

        public new Iterador<T> crearItr()
        {
            return new ItrElemDic<K,T>(Elems);
        }
    }
}
