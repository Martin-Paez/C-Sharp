using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TP.TP5.Clases;

namespace TP.TP5.Interfaces.Comparar
{
    public interface Comparador<in T>
    {
        int Comparar(T a, T b);
    }
}
