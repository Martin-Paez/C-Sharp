using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces.Comparar;

namespace TP.TP2.Colecciones
{
    public class Cola<T> : Coleccion<T> where T : Comparable<T>
    {
    }
}
