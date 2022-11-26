using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Clases;

namespace TP.TP6.Template_Method
{
    public class IMazo<C>
    {
        protected List<C> Cartas = new();
        public void Mezclar()
        {
            for (int i = 0; i < Cartas.Count; i++)
            {
                C c = Cartas[i];
                int j = new Random().Next(Cartas.Count);
                Cartas[i] = Cartas[j];
                Cartas[j] = c;
            }
        }
        public C? Repartir()
        {
            if (Cartas.Count == 0)
                return default;
            C c = Cartas[Cartas.Count-1];
            Cartas.RemoveAt(Cartas.Count - 1);
            return c;
        }
        public void Agregar(C c)
        {
            Cartas.Add(c);
        }
        public void Agregar(List<C> cartas)
        {
            if (Cartas.Count == 0)
                Cartas = cartas;
            else
                foreach (C c in cartas)
                    Agregar(c);
        }
        public void Agregar(IMazo<C> mazo)
        {
            Agregar(mazo.Cartas);
        }
        public int Size()
        {
            return Cartas.Count;
        }
        public override string ToString()
        {
            string s = "";
            foreach (C c in Cartas)
                s += c!.ToString() + " ";
            return s;
        }
    }
}
