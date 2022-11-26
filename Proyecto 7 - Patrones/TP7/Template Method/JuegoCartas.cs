using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Clases;
using TP.TP7.Template_Method.JugadorNS;

namespace TP.TP7.Template_Method
{
    public abstract class JuegoCartas<J,C> where J : Jugador<C>
    {
        protected IMazo<C> Mazo;
        protected IMazo<C> Pozo = new();
        public List<C> Mesa = new();
        public List<J>? Jugar(List<J> jugadores)
        {
            List<J>? g;
            while ((g=Ganador()) == null)
            {
                Mezclar();
                Repartir(jugadores);
                while (Ronda())
                    foreach (J j in jugadores)
                    {
                        Levantar(j);
                        Decidir(j);
                    }
                Descartar(jugadores);
            }
            return g;
        }
        public abstract void Mezclar();
        public abstract bool Ronda();
        public abstract void Repartir(List<J> jugadores);
        public abstract void Levantar(J j);
        public abstract void Decidir(J j);
        public abstract void Descartar(List<J> jugadores);
        public abstract List<J>? Ganador();
    }
}
