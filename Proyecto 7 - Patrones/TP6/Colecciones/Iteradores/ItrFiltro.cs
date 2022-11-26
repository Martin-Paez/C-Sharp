using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Interfaces.Iterador;
using TP.TP6.Interfaces.Comparar;

namespace TP.TP6.Colecciones.Iteradores
{
    public class ItrFiltro<T> : ListItr<T> where T : Comparable<T> //where T : StrategyComparable<T>
    {
        public T Patron { get; set; }
        public ItrFiltro(List<T> elems, T patron) : base(elems)
        {
            this.Patron = patron;
        }

        public override bool Sig()
        {
            while (base.Sig())
                //if ( Patron.Cmp.Comparar(Elem(), Patron) > 0 )
                if ( Elem().SosMayor(Patron) )
                    return true;
            return false;
        }
    }
}
