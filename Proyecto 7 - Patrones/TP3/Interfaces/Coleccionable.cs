using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP3.Interfaces.Comparar;
using TP.TP3.Interfaces.Iterador;

namespace TP.TP3.Interfaces
{
    public interface Coleccionable<T> : Iterable<T> where T : Comparable<T>
    {
        int Cuantos();
        T? Minimo();
        T? Maximo();
        bool Contiene(T c);
        void Agregar(T c);
    }
}
