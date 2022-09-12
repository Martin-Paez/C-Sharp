using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP2.Interfaces.Comparar;

namespace TP.TP2.Clases.Estrategias
{
    public class PorEgreso : Comparador<Egresado>
    {
        public int Comparar(Egresado a, Egresado b)
        {
            return DateTime.Compare(a.Egreso, b.Egreso);
        }
    }
}
