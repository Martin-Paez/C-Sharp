using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP2.Interfaces
{
    public interface Comparable<T>
    {
        bool SosIgual(T c);
        bool SosMayor(T c);
        bool SosMenor(T c);
    }

}
