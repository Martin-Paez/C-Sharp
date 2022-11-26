using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Colecciones
{
    public class Cola<T> : Coleccion<T> where T : Comparable<T>
    {
    }
}
