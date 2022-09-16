using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP3.Interfaces.Comparar
{
    public interface StrategyComparable<T>
    {   // Mejor no heredar de Comparable, tengo el get
        Comparador<T>? Cmp { get; set; }
    }
}
