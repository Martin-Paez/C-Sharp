using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP7.Interfaces.Comparar
{
    public interface Comparable<in T>
    {
        bool SosIgual(T c);
        bool SosMayor(T c);
        bool SosMenor(T c);
    }
}
