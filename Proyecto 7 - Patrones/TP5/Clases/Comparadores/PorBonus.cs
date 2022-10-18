using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP5.Clases.Comparables.VendedorNS;
using TP.TP5.Interfaces.Comparar;

namespace TP.TP5.Clases.Estrategias
{
    public class PorBonus : Comparador<Vendedor>
    {
        public int Comparar(Vendedor a, Vendedor b)
        {
            return (int)a.Bonus! - (int)b.Bonus!;
        }
        public override string ToString()
        {
            return "Por Bonus";
        }
    }
}
