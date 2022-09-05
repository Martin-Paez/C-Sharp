using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TP.TP2.Clases;

namespace TP.TP2.Interfaces
{
    public interface Comparador<in T>
    {
        bool SosIgual(T a, T b);
        bool SosMayor(T a, T b);
        bool SosMenor(T a, T b);
    }
}
