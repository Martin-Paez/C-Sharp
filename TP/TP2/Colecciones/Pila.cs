using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces.Comparar;

namespace TP.TP2.Colecciones
{
    public class Pila<T> : Coleccion<T> where T : Comparable<T>
    {
    }
}
