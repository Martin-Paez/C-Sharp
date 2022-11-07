using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Interfaces.Comparar;
using TP.TP5.Interfaces.Oberservar;

namespace TP.TP5.Interfaces.Iterador
{
    public class ListItr<T> : Iterador<T>
    {
        public List<T> Elems;
        int Index = -1;

        public ListItr(List<T> elems)
        {
            Elems = elems;
        }
        public virtual T Elem()
        {
            return Elems[Index];
        }
        public bool Fin()
        {
            return Index == Elems.Count;
        }
        public void Primero()
        {
            Index = -1;
        }
        public virtual bool Sig()
        {
            bool ok = Index != Elems.Count - 1;
            // si sumo de mas, cuando agreguen un elemento a la lista me lo pierdo
            if (ok)
                Index++;
            return ok;
        }
    }
}
