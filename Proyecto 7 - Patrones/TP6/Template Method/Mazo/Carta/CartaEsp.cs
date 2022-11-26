using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP6.Template_Method
{
    public class CartaEsp : ICarta
    {
        public CartaEsp.Figura Palo { get; }
        public int Num { get; }
        public enum Figura { ESPADA, BASTO, ORO, COPA };

        public CartaEsp(CartaEsp.Figura palo, int num)
        {
            Palo = palo;
            Num = num;
        }
        public override string ToString()
        {
            string[] p = {"Espada", "Basto", "Oro", "Copa"};
            return "[" + Num.ToString()  + "," + p[(int)Palo] + "]";
        }
    }
}
