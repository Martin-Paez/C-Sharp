using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Clases.Comparables.VendedorNS;
using TP.TP7.Interfaces.Comparar;

namespace TP.TP7.Clases.Estrategias
{
    public class PorSueldoBasico : Comparador<Vendedor>
    {
        public int Comparar(Vendedor a, Vendedor b)
        {
            return (int)a.SueldoBasico! - (int)b.SueldoBasico!;
        }
        public override string ToString()
        {
            return "Por Sueldo Basico";
        }
    }
}
