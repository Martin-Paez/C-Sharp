using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP7.Template_Method
{
    public class MazoEsp : IMazo<CartaEsp>
    {
        public MazoEsp()
        {
            foreach (CartaEsp.Figura palo in Enum.GetValues(typeof(CartaEsp.Figura)))
                for (int j = 1; j < 13; j++)
                    Cartas.Add(new CartaEsp(palo, j));
        }
    }
}
