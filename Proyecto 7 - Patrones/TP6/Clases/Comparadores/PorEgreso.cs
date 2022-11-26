using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP6.Clases.Comparables.AlumnoNS;
using TP.TP6.Interfaces.Comparar;

namespace TP.TP6.Clases.Estrategias
{
    public class PorEgreso : Comparador<Egresado>
    {
        public int Comparar(Egresado a, Egresado b)
        {
            return DateTime.Compare(a.Egreso, b.Egreso);
        }
        public override string ToString()
        {
            return "Por Egreso";
        }
    }
}
