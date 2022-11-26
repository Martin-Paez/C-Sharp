using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Interfaces.Comparar;
using TP.TP7.Interfaces.Iterador;

namespace TP.TP7.Interfaces
{
    public interface Coleccionable<T> : Iterable<T> where T : Comparable<T>
    {
        int Cuantos();
        T? Minimo();
        T? Maximo();
        bool Contiene(T c);
        void Agregar(T c);
        void Ordenar(IComparer<T> cmp);
    }
}
