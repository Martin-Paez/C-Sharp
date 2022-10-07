using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario.Hash
{
    public class Tupla<K,T>
    {
        public K k { get; }
        public T e { get; }
        public Tupla(K key, T e)
        {
            k = key;
            this.e = e;
        }
    }
    public class Diccionario<K,T> where K : IComparable<K>
    {
        private List<Tupla<K,T>>[] Tabla;
        public Func<K, int> hash { get; set; }

        public Diccionario(int size, Func<K, int> hash)
        {
            Tabla = new List<Tupla<K, T>>[size];
            for (int i = 0; i < size; i++)
                Tabla[i] = new List<Tupla<K, T>>();
            this.hash = (x) => { return hash(x) % Tabla.Length; };
        }
        public void Add(T e, K k)
        {
            if (e == null || k == null)
                throw new Exception();
            Tupla<K, T> t = new Tupla<K, T>(k, e);
            Tabla[hash(k)].Add(t);
        }
        public bool Contains(K key)
        {
            List<Tupla<K,T>> tuplas = Tabla[hash(key)];
            foreach (Tupla<K, T> t in tuplas)
            {
                if (t.k.CompareTo(key)==0)
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            string o = "";
            foreach (List<Tupla<K, T>> list in Tabla)
                foreach (Tupla<K, T> t in list)
                    o += "[ key: " + t.k!.ToString() + ", Elem: " + t.e!.ToString() + " ]\n";
            return o;
        }
    }
}
