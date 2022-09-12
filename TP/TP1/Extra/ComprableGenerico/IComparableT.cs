using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP1
{
    public interface ComparableT<T>
    {
        bool SosIgual(T comparable);
        bool SosMayor(T comparable);
        bool SosMenor(T comparable);

    }
}
