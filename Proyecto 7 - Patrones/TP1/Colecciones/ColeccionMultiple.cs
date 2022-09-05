using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.TP1.Interfaces;

namespace TP.TP1.Colecciones
{
    public class ColeccionMultiple : Coleccionable
    {
        Pila p;
        Cola c;

        public ColeccionMultiple(Pila p, Cola c)
        {
            this.p = p;
            this.c = c;
        }

        public void Agregar(Comparable n)
        {
            throw new NotImplementedException();
        }

        public bool Contiene(Comparable n)
        {
            return p.Contiene(n) || c.Contiene(n);
        }

        public int Cuantos()
        {
            return p.Cuantos() + c.Cuantos();
        }

        public Comparable? Maximo()
        {
            Comparable? a = p.Maximo();
            Comparable? b = c.Maximo();
            if (a == null)
                return b;
            else if (b == null)
                return a;

            if (a.SosMayor(b))
                return b;
            return a;
        }

        public Comparable? Minimo()
        {
            Comparable? a = p.Minimo();
            Comparable? b = c.Minimo();
            if (a == null)
                return b;
            else if (b == null)
                return a;

            if (a.SosMenor(b))
                return b;
            return a;
        }
    }

}
