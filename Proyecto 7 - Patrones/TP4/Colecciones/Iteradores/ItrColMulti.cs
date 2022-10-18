using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP4.Interfaces.Iterador;

namespace TP.TP4.Colecciones.Iteradores
{
    public class ItrColMulti<T> : Iterador<T>
    {
        private IList<Iterador<T>> Itrs;
        private int i=0;

        public ItrColMulti(IList<Iterador<T>> itr)
        {
            this.Itrs = itr;
        }
        public T Elem()
        {
            return Itrs[i].Elem();
        }
        public void Primero()
        {
            i = 0;
            Itrs[i].Primero();
        }
        public bool Sig()
        {
            while (!Itrs[i].Sig())
                if (++i == Itrs.Count)
                    return false;
            return true;
        }
    }
}
