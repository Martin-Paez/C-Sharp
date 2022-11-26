using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP7.Template_Method.Jugador;
using TP.TP7.Template_Method.JugadorNS;

namespace TP.TP7.Template_Method
{
    public class CasitaRobada : JuegoCartas<JugadorCRobada, CartaEsp>
    {
        private List<JugadorCRobada>? g = null;
        private int ronda = 0;
        public CasitaRobada(List<JugadorCRobada> jugadores)
        {
            Mazo = new MazoEsp();
            Mazo.Mezclar();
            for (int i = 0; i < 4; i++)
                Mesa.Add(Mazo.Repartir()!);
            MostrarMesa();
            foreach (JugadorCRobada j in jugadores)
            {
                j.Jugadores = jugadores;
                j.Mesa = Mesa;
            }
        }
        public void MostrarMesa()
        {
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("Cartas en la mesa Mesa: ");
            foreach (CartaEsp c in Mesa)
                Console.Write(c + " ");
            Console.WriteLine("\n----------------------------\n");
        }
        public override void Decidir(JugadorCRobada j)
        {
            j.Decidir();
            MostrarMesa();
        }

        public override void Descartar(List<JugadorCRobada> jugadores)
        {
            return;
        }

        public override List<JugadorCRobada>? Ganador()
        {
            return g;
        }

        public override void Levantar(JugadorCRobada j)
        {
            return;
        }

        public override void Mezclar()
        {
            Mazo.Mezclar();
        }

        public override void Repartir(List<JugadorCRobada> jugadores)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Se reparten tres cartas a cada jugador");
            Console.WriteLine("--------------------------------------\n");
            foreach (JugadorCRobada j in jugadores)
            {
                for (int i = 0; i < 3; i++)
                {
                    CartaEsp? c = Mazo.Repartir();
                    if (c == null)
                    {
                        Console.WriteLine("Se termino el mazo");
                        ElegirGanador(jugadores);
                        return;
                    }
                    j.Agarrar(c);
                }
            }
            ronda = 0;
        }
        public void ElegirGanador(List<JugadorCRobada> jugadores)
        {
            g = new List<JugadorCRobada>();
            foreach (JugadorCRobada b in jugadores)
            {
                if (g.Count==0 || g[0].Pts() == b.Pts())
                    g.Add(b);
                else if (g[0].Pts() < b.Pts())
                {
                    g.Clear();
                    g.Add(b);
                }
            }
        }
        public override bool Ronda()
        {
            return ronda++<3 && g == null;
        }
    }
}
