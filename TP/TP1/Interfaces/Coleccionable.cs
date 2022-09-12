using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP1.Interfaces
{
    public interface Coleccionable
    {
        int Cuantos();
        Comparable? Minimo();
        Comparable? Maximo();
        void Agregar(Comparable comparable);
        bool Contiene(Comparable comparable);

    }
}
