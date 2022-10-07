using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Arbol_Binario.Hash
{
    public class HashTable<T>
    {
        private List<T>[] Tabla;

        public HashTable(int size)
        {
            Tabla = new List<T>[size];
            for (int i = 0; i < Tabla.Length; i++)
                Tabla[i] = new List<T>();
        }
        public virtual void Add(T e)
        {
            if (e == null)
                throw new Exception("No se permite agregar elementos nulos");
            Get(e).Add(e);
        }
        public bool Contains(T e)
        {
            if (e == null)
                return false;
            List<T> list = Get(e);
            foreach (T i in list)
                if (i.GetHashCode() == e.GetHashCode())
                    return true;
            return false;
        }
        protected List<T> Get(T e)
        {
            return Tabla[e.GetHashCode() % Tabla.Length];
        }
        public override string ToString()
        {
            string o = "";
            foreach (List<T> list in Tabla)
                foreach (T t in list)
                    o += t!.ToString() + "\n";
            return o;
        }
    }
}
