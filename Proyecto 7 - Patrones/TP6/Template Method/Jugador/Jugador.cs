using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.TP6.Template_Method.JugadorNS
{
    public abstract class Jugador<C>
    {
        public string Nombre { get; set; }
        public List<C> Cartas = new();
        public Jugador(string nombre)
        {
            Nombre = nombre;
        }
        public void Agarrar(C carta)
        {
            Cartas.Add(carta);
        }
        public List<C> Descartar()
        {
            List<C> c = Cartas;
            Cartas = new();
            return c;
        }
        public abstract C? Decidir();
        public override string ToString()
        {
            string s = "";
            foreach (C c in Cartas)
                s += c!.ToString() + "|";
            if (s.Length > 0)
                s = s.Substring(0, s.Length - 1);
            return Nombre + " " + s;
        }
    }
}
