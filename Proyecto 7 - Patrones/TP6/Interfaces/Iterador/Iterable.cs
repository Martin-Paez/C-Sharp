using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP6.Interfaces.Iterador
{
    public interface Iterable<T>
    {
        Iterador<T> crearItr();
    }
}
