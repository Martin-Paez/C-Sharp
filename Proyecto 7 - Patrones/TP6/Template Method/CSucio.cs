using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Clases;
using TP.TP6.Template_Method.JugadorNS;

namespace TP.TP6.Template_Method
{
    public class CSucio : JuegoCartas<JugadorCSucio,CartaEsp>
    {
        private JugadorCSucio? g = null;
        private int Turno = 0;
        public CSucio()
        {
            Mazo = new MazoEsp(); 
            Mazo.Mezclar();
        }
        public override void Descartar(List<JugadorCSucio> jugadores)
        {
            foreach (JugadorCSucio j in jugadores)
                Pozo.Agregar(j.Descartar());
        }
        public override void Decidir(JugadorCSucio j)
        {
            if (g != null)
                return;
            CartaEsp c = j.Decidir();
            if (c.Palo == CartaEsp.Figura.ORO && c.Num == 1)
                g = j;
        }
        public override List<JugadorCSucio>? Ganador()
        {
            if (g == null)
                return null;
            List<JugadorCSucio> o = new();
            o.Add(g);
            return o;
        }
        public override void Levantar(JugadorCSucio j)
        {
            if (g != null)
                return;
            j.Agarrar(Mazo.Repartir()!);
            Console.WriteLine(j);
        }
        public override void Mezclar()
        {
            /*Console.WriteLine("Mezclando mazo");
            CartaEsp? c;
            while ((c = Pozo.Repartir()) != null)
                Mazo.Agregar(c);
            Mazo.Mezclar();*/
            return;
        }
        public override void Repartir(List<JugadorCSucio> jugadores)
        {
            Turno = 0;
            return;
        }
        public override bool Ronda()
        {
            return Turno++==0;
        }
    }
}
