using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP2.Interfaces
{
    public interface Iterador<T>
    {
        void primero();
        void Sig();
        bool Fin();
        T Elem();
    }

    public interface Iterable<T>
    {
        Iterador<T> CrearItr();
    }

    public class ColeccionItr<T> : Iterador<T>
    {
        private List<T> list;
        private int index = -1;

        public ColeccionItr(List<T> list)
        {
            this.list = list;
        }

        public T? Elem()
        {
            if (index < list.Count)
                index++;
            return list[index];
        }

        public bool Fin()
        {
            return index == list.Count;
        }

        public void primero()
        {
            throw new NotImplementedException();
        }

        public void Sig()
        {
            throw new NotImplementedException();
        }
    }
}
