using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;
using TP.TP5.Interfaces.Comparar;
using TP.TP5.Interfaces.Iterador;
using TP.TP5.Interfaces.Oberservar; 

namespace TP.TP5.Colecciones.ProxyColeccionableNS
{
    public class AdapterIterador<T> : Observador<ProxyColeccionable<T>,Iterador<T>>,
    Iterador<T> where T:Comparable<T>,/*por ProxyCol...*/Observable<Observador<T>>
    {
        Iterador<T> itr;
        public AdapterIterador(Iterador<T> itr)
        {
            this.itr = itr;
        }

        public T Elem()
        {
            return itr.Elem();
        }

        public void Primero()
        {
            itr.Primero();
        }

        public void RecibirNotificacion(ProxyColeccionable<T> editor, Iterador<T> info)
        {
            itr = info;
        }

        public bool Sig()
        {
            return itr.Sig();
        }
    }
}
