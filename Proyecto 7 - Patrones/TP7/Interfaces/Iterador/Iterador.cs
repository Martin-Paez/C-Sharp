using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP7.Interfaces.Iterador
{
    public interface Iterador<T>
    {
        void Primero();
        bool Sig();
        T Elem();
    }
}
