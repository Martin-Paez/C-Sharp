using TP.TP7.Template_Method.JugadorNS;

namespace TP.TP7.Template_Method.Jugador
{
    public class JugadorCRobada : Jugador<CartaEsp>
    {
        private IMazo<CartaEsp> Casita = new();
        public List<CartaEsp> Mesa { get; set; }
        public List<JugadorCRobada> Jugadores { get; set; }
        public JugadorCRobada(string nombre)
        : base(nombre) { }

        public override CartaEsp? Decidir()
        {
            foreach(JugadorCRobada jj in Jugadores)
                Console.WriteLine(jj.ToString());
            Console.WriteLine("\nTurno de {0}:", Nombre);
            CartaEsp? descarte = null;
            foreach (CartaEsp c in Cartas)
            {
                IMazo<CartaEsp>? r = null;
                JugadorCRobada? or = null;
                foreach (JugadorCRobada op in Jugadores)
                {
                    if (op != this)
                    {
                        r = op.RobarCasita(c);
                        if (r != null)
                        {
                            or = op;
                            break;
                        }
                    }
                }
                if (r != null)
                {
                    Casita.Agregar(r);
                    Cartas.Remove(c);
                    Console.WriteLine("\n  robo la casita de {0}\n\n{1}", or!.Nombre.ToString(), ToString());
                    descarte = null;
                    break;
                }
                else
                {
                    int sz = Casita.Size();
                    string s = "";
                    for (int i = 0; i < Mesa.Count; i++)
                        if (Mesa[i].Num == c.Num)
                        {
                            s += "\n  robo de la mesa un " + Mesa[i].ToString();
                            Casita.Agregar(Mesa[i]);
                            Mesa.RemoveAt(i);
                            i--;
                        }
                    if (Casita.Size() != sz)
                    {
                        Casita.Agregar(c);
                        Cartas.Remove(c);
                        Console.WriteLine(s+"\n\n{0}",ToString());
                        descarte = null;
                        break;
                    }
                    else
                        descarte = c;
                }
            }
            if (descarte != null)
            {
                Cartas.Remove(descarte);
                Console.WriteLine("\n  descarta un {0}\n\n{1}", descarte.ToString(), ToString());
                Mesa.Add(descarte);
            }
                
            return descarte;
        }
        public IMazo<CartaEsp>? RobarCasita(CartaEsp c)
        {
            CartaEsp? t = Casita.Repartir();
            if (t != null)
                if (c.Num == t.Num)
                {
                    Casita.Agregar(c);
                    Casita.Agregar(t);
                    IMazo<CartaEsp> m = Casita;
                    Casita = new();
                    return m;
                }
            else
                Casita.Agregar(t);
            return default;
        }
        public int Pts()
        {
            return Casita.Size();
        }
        public override string ToString()
        {
            string s = "";
            foreach (CartaEsp c in Cartas)
                s += "[" + c!.Num.ToString() + "] ";
            if (s.Length > 0)
                s = s.Substring(0, s.Length - 1);
            s = Nombre + " " + s;
            if (Casita.Size() > 0)
            {
                CartaEsp c = Casita.Repartir()!;
                s += "\nCasita: " + (Casita.Size()+1).ToString() + " Tope: " + c.ToString();
                Casita.Agregar(c);
            }
            return s;
        }
    }
}
