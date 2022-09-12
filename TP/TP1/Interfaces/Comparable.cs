using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP1.Interfaces
{
    public interface Comparable
    {
        bool SosIgual(Comparable comparable);
        bool SosMayor(Comparable comparable);
        bool SosMenor(Comparable comparable);
    }

}
