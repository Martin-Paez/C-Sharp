using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Clases.Comparables.AlumnoNS;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Clases.Estrategias
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
