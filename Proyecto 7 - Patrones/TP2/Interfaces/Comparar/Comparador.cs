using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TP.TP2.Clases;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP2.Interfaces.Comparar
{
    public interface Comparador<in T>
    {
        public int Comparar(T a, T b);
    }
 }
