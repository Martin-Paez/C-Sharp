using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TP.TP2.Clases;

namespace TP.TP2.Interfaces.Comparar
{
    public interface Comparador<in T>
    {
        int Comparar(T a, T b);
    }
}
