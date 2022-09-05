using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP2.Interfaces
{
    public interface Coleccionable<T>
    {
        int Cuantos();
        T? Minimo();
        T? Maximo();
        void Agregar(T c);
        bool Contiene(Comparable<T> c);

    }
}
