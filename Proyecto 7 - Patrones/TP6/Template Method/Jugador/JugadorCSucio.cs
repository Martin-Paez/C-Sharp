using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP6.Template_Method.JugadorNS
{
    public class JugadorCSucio : Jugador<CartaEsp>
    {
        public JugadorCSucio(string nombre) : base(nombre)
        {
        }
        public override CartaEsp Decidir()
        {
            if (Cartas.Count == 0)
                    throw new Exception("No tengo cartas para jugar");
            CartaEsp c = Cartas[0];
            Cartas.Clear();
            return c;
        }
    }
}
