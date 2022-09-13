using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TP.TP3.Clases;

namespace TP.TP3.Interfaces.Comparar
{
    public interface Comparador<in T>
    {
        int Comparar(T a, T b);
    }
}
