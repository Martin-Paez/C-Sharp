using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP3.Interfaces.Iterador
{
    public interface Iterable<T>
    {
        Iterador<T> crearItr();
    }
}
